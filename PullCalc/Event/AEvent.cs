using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc.Event;
internal abstract class AEvent
{
    internal abstract int[] ExpectedStageOp { get; }
    internal abstract int ExpectedShopSinglePulls { get; }
}
