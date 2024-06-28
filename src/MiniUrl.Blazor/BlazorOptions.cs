namespace MiniUrl.Blazor;

internal sealed record BlazorOptions
{
    public string BaseAddress { get; set; } = string.Empty;
}