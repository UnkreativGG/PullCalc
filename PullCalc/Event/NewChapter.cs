namespace PullCalc.Event;
internal class NewChapter : AEvent
{
    internal override int[] ExpectedStageOp => [18, 18];

    internal override int ExpectedShopSinglePulls => 0;
}
