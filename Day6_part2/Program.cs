using Day6_part2;

var races = new List<Race>
{
    new()
    {
        Time = 56977875,
        DistanceToBeat = 546192711311139
    }
};

foreach (var race in races)
{
    for (long speed = 0; speed < race.Time; speed++)
    {
        var distance = (race.Time - speed) * speed;

        if (distance > race.DistanceToBeat)
        {
            race.WaysToWin++;
        }
    }
}

Console.WriteLine(races.Select(x=>x.WaysToWin).Aggregate((total, next) => total * next));