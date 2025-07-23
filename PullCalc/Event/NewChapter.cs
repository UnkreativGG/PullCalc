using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc.Event;
internal class NewChapter : AEvent
{
    internal override int[] ExpectedStageOp => [18, 18];

    internal override int ExpectedShopSinglePulls => 0;
}
