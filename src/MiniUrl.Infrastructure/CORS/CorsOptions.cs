namespace MiniUrl.Infrastructure.Cors;

internal sealed record CorsOptions
{
    public bool Enabled { get; set; }
    public IEnumerable<string> AllowedOrigins { get; set; } = new List<string>();
    public IEnumerable<string> AllowedMethods { get; set; } = new List<string>();
    public IEnumerable<string> AllowedHeaders { get; set; } = new List<string>();
}