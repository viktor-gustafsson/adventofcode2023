using Day6;

var races = new List<Race>
{
    new()
    {
        Time = 56,
        DistanceToBeat = 546
    },
    new()
    {
        Time = 97,
        DistanceToBeat = 1927
    },
    new()
    {
        Time = 78,
        DistanceToBeat = 1131
    },
    new()
    {
        Time = 75,
        DistanceToBeat = 1139
    }
};

foreach (var race in races)
{
    for (var speed = 0; speed < race.Time; speed++)
    {
        var distance = (race.Time - speed) * speed;

        if (distance > race.DistanceToBeat)
        {
            race.WaysToWin++;
        }
    }
}

Console.WriteLine(races.Select(x=>x.WaysToWin).Aggregate((total, next) => total * next));