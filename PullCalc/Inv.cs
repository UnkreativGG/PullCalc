using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc;
internal class Inv
{
    internal int Orundum;
    internal int OriginumPrime;
    internal int SinglePull;
    internal int TenPulls;

    internal int PrimeRemaining;

    public int GetPulls()
    {
        return (OriginumPrime * 180 + Orundum) / 600 + SinglePull + TenPulls * 10;
    }

    public Inv() { }
    public Inv(Inv invToCoppy)
    {
        Orundum = invToCoppy.Orundum;
        OriginumPrime = invToCoppy.OriginumPrime;
        SinglePull = invToCoppy.SinglePull;
        TenPulls = invToCoppy.TenPulls;
        PrimeRemaining = invToCoppy.PrimeRemaining;
    }
}
