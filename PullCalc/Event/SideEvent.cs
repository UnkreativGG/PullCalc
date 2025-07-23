using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc.Event;
internal class SideEvent : AEvent
{
    internal override int[] ExpectedStageOp => [8 * 2 + 2];

    internal override int ExpectedShopSinglePulls => 0;
}
