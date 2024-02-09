namespace MiniUrl.Infrastructure.Time;

internal sealed class UtcClock : IClock
{
    public DateTime Now() => DateTime.UtcNow;
    public DateTime MaxValue() => DateTime.MaxValue;
}