using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc.Event;
internal class StandardEvent : AEvent
{
    internal override int[] ExpectedStageOp => [8 , (2 * 8)];

    internal override int ExpectedShopSinglePulls => 2;
}
