using PullCalc;
using PullCalc.Banner;
using PullCalc.Event;

ABanner[] banners =
[
    //new LimitedBanner("Pepe", new DateTime(2025, 1, 5), null, null, new LargeEvent()),

    //new StandardBanner("Pink girl", new DateTime(2025, 2, 5), null, 90, new SideEvent()),
    //new CollabBanner("Food", new DateTime(2025, 3, 7), null, -1, new StandardEvent()),
    //new StandardBanner("Siege", new DateTime(2025, 4, 6), null, null, new SideEvent()),

    //new LimitedBanner("laptop", new DateTime(2025, 4, 24), null, -1, new LargeEvent()),
    //new StandardBanner("thorny", new DateTime(2025, 6, 5), null, null, new StandardEvent()),
    new LimitedBanner("blazing sun", new DateTime(2025, 7, 5), null, null, new LargeEvent()),
    
    new StandardBanner("red'n'black", new DateTime(2025, 8, 5), null, null, new StandardEvent()),
    new StandardBanner("anti reed", new DateTime(2025, 9, 5), null, null, new StandardEvent()),
    new StandardBanner("energy drink", new DateTime(2025, 10, 5), null, null, new NewChapter()),
    
    new LimitedBanner("Laterano", new DateTime(2025, 11, 7), null, -1, new LargeEvent()),
    new StandardBanner("opera singer", new DateTime(2025, 12, 8), null, null, new StandardEvent()),
    new StandardBanner("lezi", new DateTime(2026, 01, 5), null, null, new SideEvent()),
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