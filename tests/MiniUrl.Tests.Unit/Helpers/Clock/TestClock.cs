using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Tests.Unit.Helpers.Clock;

public class TestClock : IClock
{
    public DateTime Now() => DateTime.Parse("08/02/2024");
}