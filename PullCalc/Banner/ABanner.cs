using PullCalc.Event;

namespace PullCalc.Banner;
internal abstract class ABanner(string name, DateTime releaseDate, DateTime? endDate, int? maxPulls, AEvent? attachedEvent = null)
{
    internal string Name = name;
    internal DateTime ReleaseDate = releaseDate;
    internal DateTime? EndDate = endDate;

    internal int DaysOfExistence => EndDate.HasValue ? (int)(EndDate.Value - ReleaseDate).TotalDays : DefaultDaysOfExistence;
    internal const int DefaultDaysOfExistence = 14;

    internal AEvent? AttachedEvent = attachedEvent;

    internal int? MaxPulls = maxPulls;


    internal abstract int HardPity { get; }

    internal abstract bool Free10Pull { get; }
    internal abstract bool FreeDailyPull { get; }
    internal abstract int AverageDailyOrundum { get; }
}