using PullCalc;
using PullCalc.Banner;
using PullCalc.Event;

ABanner[] banners =
[  
    new StandardBanner("red'n'black", new DateTime(2025, 8, 5), null, null, new StandardEvent()),
    new StandardBanner("anti reed", new DateTime(2025, 9, 5), null, null, new StandardEvent()),
    new StandardBanner("energy drink", new DateTime(2025, 10, 5), null, null, new NewChapter()),
    
    new LimitedBanner("Laterano", new DateTime(2025, 11, 7), null, -1, new LargeEvent()),
    new StandardBanner("opera singer", new DateTime(2025, 12, 8), null, null, new StandardEvent()),
    new StandardBanner("lezi", new DateTime(2026, 02, 10), null, null, new SideEvent()),

    new LimitedBanner("Tomboy", new DateTime(2026, 01, 9), null, null, new LargeEvent()),
];

Inv inv = new()
{
    Orundum = 68919,
    OriginumPrime = 697,
    SinglePull = 34,
    TenPulls = 0,
    PrimeRemaining = 0,
};

CalcV3.Calculate(inv, banners, reportGains: false);

Console.ReadKey();