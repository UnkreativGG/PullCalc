using PullCalc.Event;

namespace PullCalc.Banner;
internal class LimitedBanner(string name, DateTime releaseDate, DateTime? endDate, int? maxPulls, AEvent? attachedEvent = null) : ABanner(name, releaseDate, endDate, maxPulls, attachedEvent)
{
    internal override int HardPity => 300;

    internal override bool Free10Pull => true;

    internal override bool FreeDailyPull => true;

    internal override int AverageDailyOrundum => 400;
}
