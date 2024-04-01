var histories = File.ReadAllLines("C:\\develop\\AdventOfCode2023\\Day9\\input.txt");
var sum = 0;

foreach (var history in histories)
{
    var strings = history.Split(' ').Select(int.Parse).ToList();
    var output = new List<List<int>>();
    
    TraverseDown(strings, output);
    sum += TraverseUp(output);
}

void TraverseDown(List<int> input, List<List<int>> output)
{
    if (output.Count == 0)
        output.Add(input);

    var differences = new List<int>();
    for (var i = 1; i < input.Count; i++)
    {
        var difference = input[i] - input[i - 1];
        differences.Add(difference);
    }

    if (differences.Any(x => x != 0))
    {
        output.Add(differences);
        TraverseDown(differences, output);
    }
    else
        output.Add(differences);
}

int TraverseUp(List<List<int>> input)
{
    input.Reverse();
    input[0].Add(0);
    for (var i = 0; i < input.Count - 1; i++)
    {
        var last = input[i].Last() + input[i + 1].Last();
        input[i + 1].Add(last);
    }

    return input.Last().Last();
}

Console.WriteLine(sum);