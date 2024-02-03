using Microsoft.Extensions.Caching.Distributed;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using Newtonsoft.Json;

namespace MiniUrl.Infrastructure.Caching.Decorators;

internal sealed class CachedUrlRepository : IUrlRepository
{
    private readonly IUrlRepository _urlRepository;
    private readonly IDistributedCache _distributedCache;

    public CachedUrlRepository(IUrlRepository urlRepository, IDistributedCache distributedCache)
    {
        _urlRepository = urlRepository;
        _distributedCache = distributedCache;
    }
    
    public async Task<ShortenedUrl> GetAsync(Code code)
    {
        var key = $"url-{code.Value}";

        var cachedUrl = await _distributedCache.GetStringAsync(key);

        ShortenedUrl url;
        if (string.IsNullOrWhiteSpace(cachedUrl))
        {
            url = await _urlRepository.GetAsync(code);

            if (url is null)
            {
                return null;
            }

            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(url));

            return url;
        }

        url = JsonConvert.DeserializeObject<ShortenedUrl>(cachedUrl);

        return url;
    }

    public async Task AddAsync(ShortenedUrl shortenedUrl)
        => await _urlRepository.AddAsync(shortenedUrl);

    public async Task<bool> AnyAsync(Code code)
        => await _urlRepository.AnyAsync(code);
}