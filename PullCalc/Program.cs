using PullCalc;
using PullCalc.Banner;
using PullCalc.Event;

ABanner[] banners =
[  
    new StandardBanner("anti reed", new DateTime(2025, 9, 5), null, null, new StandardEvent()),
    new StandardBanner("energy drink", new DateTime(2025, 10, 5), null, null, new NewChapter()),
    
    new LimitedBanner("Laterano", new DateTime(2025, 11, 7), null, -1, new LargeEvent()),
    new StandardBanner("opera singer", new DateTime(2025, 12, 8), null, null, new StandardEvent()),
    new StandardBanner("lezi", new DateTime(2026, 02, 10), null, null, new SideEvent()),

    new LimitedBanner("Tomboy", new DateTime(2026, 01, 16), null, null, new LargeEvent()),
    new CollabBanner("Thorns power crep", new DateTime(2026, 03, 20), null, -1, new StandardEvent()),
];

Inv inv = new()
{
    Orundum = 96200,
    OriginumPrime = 762,
    SinglePull = 41,
    TenPulls = 0,
    PrimeRemaining = 0,
};

CalcV3.Calculate(inv, banners, reportGains: false);

Console.ReadKey();