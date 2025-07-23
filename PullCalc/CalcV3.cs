using PullCalc.Banner;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullCalc;
internal class CalcV3
{
    internal static void Calculate(Inv inv, ABanner[] banners, bool reportGains)
    {
        DateTime start = DateTime.Now;
        DateTime time = start;
        DateTime end = DateTime.Now;


        foreach (ABanner banner in banners)
        {
            DateTime dt = banner.ReleaseDate + TimeSpan.FromDays(banner.DaysOfExistence);
            if (dt > end)
                end = dt;
        }


        int totalPullsSpend = 0;
        PrintTotal(inv, totalPullsSpend);

        while (time.DoSmallerEqual(end))
        {
            if (reportGains) Console.WriteLine("Gains on " + time.DoToString());
            MakeStandardGains(time, inv, reportGains);
            MakeBannerAndEventGains(time, banners, inv, reportGains);
            if (reportGains) Console.WriteLine();

            MakeBannerPulls(time, banners, ref totalPullsSpend, out bool reportTotal);

            if (reportTotal)
                PrintTotal(inv, totalPullsSpend);

            time = time.AddDays(1);
        }
    }



    static void PrintTotal(Inv inv, int totalPullsSpend)
    {
        Console.WriteLine("Total: " + (inv.GetPulls() - totalPullsSpend) + " pulls remaining");
        Console.WriteLine();
        Console.WriteLine();
    }



    static void MakeBannerPulls(DateTime time, ABanner[] banners, ref int totalPullsSpend, out bool reportTotal)
    {
        reportTotal = false;

        foreach (ABanner banner in banners)
        {
            if (time.DoEqual(banner.ReleaseDate.AddDays(banner.DaysOfExistence)))
            {
                Console.WriteLine("Banner: " + banner.Name);

                if (banner.MaxPulls != null)
                {
                    Console.WriteLine("    " + "Pulling date: " + time.DoToString() + " on a " + time.DayOfWeek.ToString());

                    int maxPulls = banner.MaxPulls == -1 ? banner.HardPity : (int)banner.MaxPulls;
                    Console.WriteLine("    " + maxPulls + " to make");

                    int freePulls = 0;
                    if (banner.Free10Pull)
                        freePulls += 10;
                    if (banner.FreeDailyPull)
                        freePulls += banner.DaysOfExistence;
                    Console.WriteLine("    " + freePulls + " free pulls");                    

                    int thisPullsSpend = maxPulls - freePulls;
                    Console.WriteLine("    " + thisPullsSpend + " pulls spend");

                    totalPullsSpend += thisPullsSpend;
                }
                else
                {
                    Console.WriteLine("    " + "skipped");
                }

                Console.WriteLine();
                reportTotal = true;
            }
        }
    }



    static void MakeBannerAndEventGains(DateTime time, ABanner[] banners, Inv inv, bool reportGains)
    {
        foreach (ABanner banner in banners)
        {
            if (banner.AttachedEvent != null)
                for (int i = 0; i < banner.AttachedEvent.ExpectedStageOp.Length; i++)
                    if (banner.ReleaseDate.AddDays(7 * i).DoEqual(time))
                    {
                        inv.OriginumPrime += banner.AttachedEvent.ExpectedStageOp[i];
                        ReportGains("- " + banner.AttachedEvent.ExpectedStageOp[i] + " Originum from event mission.", reportGains);
                    }

            if (banner.AttachedEvent != null)
                if (time.DoEqual(banner.ReleaseDate.AddDays(1)))
                {
                    inv.SinglePull += banner.AttachedEvent.ExpectedShopSinglePulls;
                    ReportGains("- " + banner.AttachedEvent.ExpectedShopSinglePulls + " SinglePull from event shop.", reportGains);
                }

            if (time.DoLargerEqual(banner.ReleaseDate) && time.DoSmallerEqual(banner.ReleaseDate.AddDays(banner.DaysOfExistence)))
                if (banner.AverageDailyOrundum > 0)
                {
                    inv.Orundum += banner.AverageDailyOrundum;
                    ReportGains("- " + banner.AverageDailyOrundum + " Orundum from limited banner gifts.", reportGains);
                }
        }
    }



    static void MakeStandardGains(DateTime time, Inv inv, bool reportGains)
    {
        inv.Orundum += 100; ReportGains("- 100 Orundum from daily mission.", reportGains);

        if (inv.PrimeRemaining > 0)
        {
            inv.Orundum += 200; ReportGains("- 200 Orundum from MonthlyPass.", reportGains);
            inv.PrimeRemaining--;
        }

        switch (time.DayOfWeek)
        {
            case DayOfWeek.Monday:
                inv.Orundum += 1800; ReportGains("- 1800 Orundum from Anihilation.", reportGains);
                break;
            case DayOfWeek.Sunday:
                inv.Orundum += 500; ReportGains("- 500 Orundum from weekly mission.", reportGains);
                break;
        }

        switch (time.Day)
        {
            case 1:
                inv.Orundum += 600; ReportGains("- 600 Orundum from Cert Shop stage I.", reportGains);
                inv.SinglePull += 2; ReportGains("- 2 SinglePull from Cert Shop stage I.", reportGains);
                inv.SinglePull += 2; ReportGains("- 2 SinglePull from Cert Shop stage II.", reportGains);
                break;
            case 17:
                inv.SinglePull += 1; ReportGains("- 1 SinglePull from LogIn rewards.", reportGains);
                break;
        }

    }

    static void ReportGains(string str, bool reportGains = false)
    {
        if (reportGains)
            Console.WriteLine(str);
    }
}
