namespace MiniUrl.Infrastructure.Time;

public interface IClock
{
    DateTime Now();
    DateTime MaxValue();
}