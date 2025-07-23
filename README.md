This is a simple calculator I use to see if I can affort to pull on a banner.

---

## Usage:

Go to Program.cs

Modify the banners like you would like to pull on like 

```c#
ABanner[] banners =
[    
    new StandardBanner("opera singer", new DateTime(2025, 12, 8), null, null, new StandardEvent()),
    // replace StandardBanner with fitting banner
    new StandardBanner(name: "lezi",
                       releaseDate: new DateTime(2026, 01, 5),
                       endDate: null,  // keep at null, I dont know if this works, will automaticly use default durations
                       maxPulls: null, // null -> skip, -1 -> go to hard pity
                       attachedEvent: new SideEvent()
                       ),
];
```

Then enter your current stuff you own.

```c#
Inv inv = new()
{
    Orundum = 68919,
    OriginumPrime = 697,
    SinglePull = 34,
    TenPulls = 0,
    PrimeRemaining = 0,
};
```

At last run.

```c#
CalcV3.Calculate(inv, banners, reportGains: false); // set true for detailed breakdown of all earnings
```
