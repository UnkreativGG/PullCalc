using PullCalc.Event;

namespace PullCalc.Banner;
internal class CollabBanner(string name, DateTime releaseDate, DateTime? endDate, int? maxPulls, AEvent? attachedEvent = null) : ABanner(name, releaseDate, endDate, maxPulls, attachedEvent)
{
    internal override int HardPity => 120;

    internal override bool Free10Pull => true;

    internal override bool FreeDailyPull => true; // actually 2 free 10 and no daily

    internal override int AverageDailyOrundum => 400;
}
