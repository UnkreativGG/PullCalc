using PullCalc.Banner;

namespace PullCalc;
internal class CalcV2(Inv inv, ABanner[] banners)
{
    const int dayToPull = 10;

    private readonly Inv Inv = inv;
    private readonly ABanner[] Banners = banners;

    private DateTime CurrentDay = DateTime.Now;
    private int TotalPullsSpend;


    const string GabAtStart = "  ";

    internal void Calculate(bool logGains)
    {
        if (CurrentDay.Day == dayToPull)
            CurrentDay = CurrentDay.AddDays(-1);

        int longestName = 0;

        foreach (ABanner banner in Banners)
            if (banner.Name.Length > longestName)
                longestName = banner.Name.Length;

        TotalPullsSpend = 0;



        Console.WriteLine("{0} pulls remaining", Inv.GetPulls() - TotalPullsSpend);
        Console.WriteLine();

        foreach (ABanner banner in Banners)
        {
            Console.WriteLine();

            if (banner.AttachedEvent != null)
            {
                SimulateTilNextBanner(logGains);

                Inv.OriginumPrime += banner.AttachedEvent.ExpectedStageOp.Sum();
                Inv.SinglePull += banner.AttachedEvent.ExpectedShopSinglePulls;
            }

            if (banner.MaxPulls != null)
            {
                int pullsMade = banner.MaxPulls == -1 ? banner.HardPity : (int)banner.MaxPulls;
                int freePulls = (banner.FreeDailyPull ? 10 : 0) + (banner.Free10Pull ? 10 : 0);
                int pullsSpend = pullsMade - freePulls;
                TotalPullsSpend += pullsSpend;

                LogBanner(banner, "max " + pullsSpend + " pulls");
            }
            else
            {
                LogBanner(banner, "Skipped");
            }
        }

        if (logGains)
            for (int i = 0; i < 12; i++)
                SimulateTilNextBanner(true);
    }



    private void SimulateTilNextBanner(bool logGains)
    {
        DateTime nextBannerPullime = CurrentDay;

        do
            nextBannerPullime = nextBannerPullime.AddDays(1);
        while (nextBannerPullime.Day != dayToPull);


        while (CurrentDay <= nextBannerPullime)
        {
            if (logGains)
                StartLog();

            Inv.Orundum += 100; // Daily Missions
            LogRecouceGain("Gained 100 Orundum from daily mission.", logGains);

            if (Inv.PrimeRemaining > 0)
            {
                Inv.Orundum += 200;
                LogRecouceGain("Gained 200 Orundum from MonthlyPass.", logGains);
                Inv.PrimeRemaining--;
            }

            switch (CurrentDay.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Inv.Orundum += 1800; // Annihilation
                    LogRecouceGain("Gained 1800 Orundum from Anihilation.", logGains);
                    break;
                case DayOfWeek.Sunday:
                    Inv.Orundum += 500; // Weekly mission
                    LogRecouceGain("Gained 500 Orundum from weekly mission.", logGains);
                    break;
            }

            switch (CurrentDay.Day)
            {
                case 1:
                    Inv.Orundum += 600; // Green Cert Shop stage 1
                    LogRecouceGain("Gained 600 Orundum from Cert Shop stage I.", logGains);
                    Inv.SinglePull += 2; // Green Cert Shop stage 1
                    LogRecouceGain("Gained 2 SinglePull from Cert Shop stage I.", logGains);
                    Inv.SinglePull += 2; // Green Cert Shop stage 2
                    LogRecouceGain("Gained 2 SinglePull from Cert Shop stage II.", logGains);
                    break;
                case 17:
                    Inv.SinglePull += 1; // Log In rewards
                    LogRecouceGain("Gained 1 SinglePull from LogIn rewards.", logGains);
                    break;
            }

            CurrentDay = CurrentDay.AddDays(1);

            if (logGains)
                EndLog();
        }
    }

    private void LogBanner(ABanner banner, string message)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;

        StartLog();

        Console.WriteLine(GabAtStart + banner.Name);
        Console.WriteLine(GabAtStart + banner.GetType().Name);
        Console.WriteLine(GabAtStart + message);

        EndLog();

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
    }


    private void StartLog()
    {
        Console.WriteLine("{0}.{1}.{2} {3}.", CurrentDay.Day, CurrentDay.Month, CurrentDay.Year, CurrentDay.DayOfWeek);
    }


    private void LogRecouceGain(string message, bool logGains)
    {
        if (logGains)
            Console.WriteLine(GabAtStart + "- " + message);
    }

    private void EndLog()
    {
        Console.WriteLine(GabAtStart + "{0} pulls remaining", Inv.GetPulls() - TotalPullsSpend);
        Console.WriteLine();
    }
}
