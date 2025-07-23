using PullCalc.Event;

namespace PullCalc.Banner;
internal class StandardBanner(string name, DateTime releaseDate, DateTime? endDate, int? maxPulls, AEvent? attachedEvent = null) : ABanner(name, releaseDate, endDate, maxPulls, attachedEvent)
{
    internal override int HardPity => 250;

    internal override bool Free10Pull => false;

    internal override bool FreeDailyPull => false;

    internal override int AverageDailyOrundum => 0;
}
