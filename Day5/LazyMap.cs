namespace Day5;

public class LazyMap
{
    private readonly List<(long sourceStart, long range, long offset)> _mappings = [];

    public void AddRangeMapping(string mapping)
    {
        var parts = mapping.Split(" ");
        var destinationStart = long.Parse(parts[0]);
        var sourceStart = long.Parse(parts[1]);
        var range = long.Parse(parts[2]);
        var offset = destinationStart - sourceStart;

        _mappings.Add((sourceStart, range, offset));
    }

    public long? this[long? source]
    {
        get
        {
            foreach (var (sourceStart, range, offset) in _mappings)
            {
                if (source >= sourceStart && source < sourceStart + range)
                {
                    return source + offset;
                }
            }

            return source;
        }
    }
}