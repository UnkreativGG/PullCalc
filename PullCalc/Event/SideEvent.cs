namespace PullCalc.Event;
internal class SideEvent : AEvent
{
    internal override int[] ExpectedStageOp => [8 * 2 + 2];

    internal override int ExpectedShopSinglePulls => 0;
}
