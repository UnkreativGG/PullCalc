using PullCalc.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PullCalc;
internal class CalcV1
{
    internal static Inv PullsInFuture(DateTime date, Inv inv)
    {
        Inv nInv = new(inv);
        DateTime currentDay = DateTime.Now;

        while (currentDay <= date)
        {
            nInv.Orundum += 100; // Daily Missions
            if (nInv.PrimeRemaining > 0)
            {
                nInv.Orundum += 200;
                nInv.PrimeRemaining--;
            }

            switch (currentDay.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    nInv.Orundum += 1800; // Annihilation
                    break;
                case DayOfWeek.Sunday:
                    nInv.Orundum += 500; // Weekly mission
                    break;
            }

            switch (currentDay.Day)
            {
                case 1:
                    nInv.Orundum += 600; // Green Cert Shop stage 1
                    nInv.SinglePull += 2; // Green Cert Shop stage 1
                    nInv.SinglePull += 2; // Green Cert Shop stage 2
                    break;
                case 17:
                    nInv.SinglePull += 1; // Log In rewards
                    break;
            }


            currentDay = currentDay.AddDays(1);
        }




        return nInv;
    }


    internal static void PrintOut(Inv inv, ABanner[] banners)
    {
        int longestName = 0;

        foreach (ABanner banner in banners)
            if (banner.Name.Length > longestName)
                longestName = banner.Name.Length;

        int pullsSpend = 0;

        Console.WriteLine("{0} pulls remaining", inv.GetPulls() - pullsSpend);
        Console.WriteLine();

        foreach (ABanner banner in banners)
        {
            if (banner.AttachedEvent != null)
            {
                inv.OriginumPrime += banner.AttachedEvent.ExpectedStageOp.Sum();
                inv.SinglePull += banner.AttachedEvent.ExpectedShopSinglePulls;
            }

            if (banner.MaxPulls != null)
            {
                int pullsSpendThisBanner = banner.MaxPulls == -1 ? banner.HardPity : (int)banner.MaxPulls;
                pullsSpend += pullsSpendThisBanner;
                Console.WriteLine("{0," + (-longestName) + "} : max {1,-3} pulls", banner.Name, pullsSpendThisBanner);
            }
            else
            {
                Console.WriteLine("{0," + (-longestName) + "} : skipped", banner.Name);
            }

            Console.WriteLine("{0} pulls remaining", inv.GetPulls() - pullsSpend);
            Console.WriteLine();
        }
    }
}
