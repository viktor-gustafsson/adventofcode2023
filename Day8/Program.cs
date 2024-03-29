var mapAndDirections = File.ReadAllLines("C:\\develop\\AdventOfCode2023\\Day8\\input.txt");

var start = "AAA";
var end = "ZZZ";

var dictionary = new Dictionary<string,(string Left,string Right)>();
var directions = mapAndDirections.First(x => !string.IsNullOrEmpty(x));
var map = mapAndDirections.Except(new[] { directions, "" }).ToArray();
foreach (var m in map)
{
    var entry = m[..3];
    var leftExit = m.Substring(7,3);
    var rightExit = m.Substring(12,3);
    dictionary[entry] = (Left: leftExit, Right: rightExit);
}

var next = start;
var directionIndex = 0;
var stepsCounter = 0;
while (next != end)
{
    if(next == "ZZZ")
        break;
    
    var (left, right) = dictionary[next];
    next = directions[directionIndex] == 'L' ? left : right;

    if (directionIndex == directions.Length - 1)
        directionIndex = 0;
    else
        directionIndex++;

    stepsCounter++;
}

Console.WriteLine(stepsCounter);