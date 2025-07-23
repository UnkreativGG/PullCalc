using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc.Event;
internal class LargeEvent : AEvent
{
    internal override int[] ExpectedStageOp => [8 , 8 * 2, 4 * 2 + 1];

    internal override int ExpectedShopSinglePulls => 3;
}
