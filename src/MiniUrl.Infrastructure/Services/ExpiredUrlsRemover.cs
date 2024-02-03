using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiniUrl.Infrastructure.EF;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Infrastructure.Services;

internal sealed class ExpiredUrlsRemover : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ExpiredUrlsRemover> _logger;
    private readonly IClock _clock;
    private Timer _timer;

    public ExpiredUrlsRemover(IServiceProvider serviceProvider, ILogger<ExpiredUrlsRemover> logger, IClock clock)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _clock = clock;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
    }

    private async void DoWork(object state)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MiniUrlDbContext>();
            var distributedCache = scope.ServiceProvider.GetRequiredService<IDistributedCache>();
            
            var expiredUrls = await dbContext.ShortenedUrls.Where(x => x.Expiry < _clock.Now()).ToListAsync();
            foreach (var url in expiredUrls)
            {
                var key = $"url-{url.Code.Value}";
                await distributedCache.RemoveAsync(key);
            }
            
            dbContext.RemoveRange(expiredUrls);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}