using System.Text;
using AdventOfCode;

var schematic = File.ReadLines("C:\\develop\\AdventOfCode2023\\Day3\\input.txt").ToList();
var parts = new List<Part>();
var hasMarker = false;
var array2D = new char[schematic.Count, schematic[0].Length];

for (var i = 0; i < schematic.Count; i++)
{
    for (var j = 0; j < schematic[i].Length; j++)
    {
        array2D[i, j] = schematic[i][j];
    }
}

for (var i = 0; i < array2D.GetLength(0); i++)
{
    var partNumberBuilder = new StringBuilder();
    for (var j = 0; j < array2D.GetLength(1); j++)
    {
        if (char.IsNumber(array2D[i, j]))
        {
            partNumberBuilder.Append(array2D[i, j]);
            
            //Up
            if (i > 0)
                if (!char.IsNumber(array2D[i - 1, j]) && array2D[i - 1, j] != '.')
                    hasMarker = true;

            //Down
            if (i < array2D.GetLength(0) - 1)
                if (!char.IsNumber(array2D[i + 1, j]) && array2D[i + 1, j] != '.')
                    hasMarker = true;
        
            // Left
            if (j > 0)
                if (!char.IsNumber(array2D[i, j - 1]) && array2D[i, j - 1] != '.')
                    hasMarker = true;

            // Right
            if (j < array2D.GetLength(1) - 1)
                if (!char.IsNumber(array2D[i, j + 1]) && array2D[i, j + 1] != '.')
                    hasMarker = true;
            
            // Diagonal Up Left
            if (i > 0 && j > 0)
                if (!char.IsNumber(array2D[i - 1, j - 1]) && array2D[i - 1, j - 1] != '.')
                    hasMarker = true;
            
            // Diagonal Up Right
            if (i > 0 && j < array2D.GetLength(1) - 1)
                if (!char.IsNumber(array2D[i - 1, j + 1]) && array2D[i - 1, j + 1] != '.')
                    hasMarker = true;
            
            // Diagonal Down Left
            if (i < array2D.GetLength(0) - 1 && j > 0)
                if (!char.IsNumber(array2D[i + 1, j - 1]) && array2D[i + 1, j - 1] != '.')
                    hasMarker = true;
            
            // Diagonal Down Right
            if (i < array2D.GetLength(0) - 1 && j < array2D.GetLength(1) - 1)
                if (!char.IsNumber(array2D[i + 1, j + 1]) && array2D[i + 1, j + 1] != '.')
                    hasMarker = true;
        }
        else if (partNumberBuilder.Length > 0)
        {
            parts.Add(new Part
            {
                Number = int.Parse(partNumberBuilder.ToString()),
                HasMarker = hasMarker
            });
            partNumberBuilder.Clear();
            hasMarker = false;
        }
    }
    if (partNumberBuilder.Length > 0)
    {
        parts.Add(new Part
        {
            Number = int.Parse(partNumberBuilder.ToString()),
            HasMarker = hasMarker
        });
        partNumberBuilder.Clear();
        hasMarker = false;
    }
}

Console.WriteLine(parts.Where(x => x.HasMarker).Select(x => x.Number).ToList().Sum());