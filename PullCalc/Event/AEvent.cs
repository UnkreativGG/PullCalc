namespace PullCalc.Event;
internal abstract class AEvent
{
    internal abstract int[] ExpectedStageOp { get; }
    internal abstract int ExpectedShopSinglePulls { get; }
}
