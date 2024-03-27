using Day4;

var tickets = File.ReadLines("C:\\develop\\AdventOfCode2023\\Day4\\input.txt").ToList();
var games = new List<Ticket>();
foreach (var ticket in tickets)
{
    var gameScore = 0;
    var gameAndNumbers = ticket.Split(':');
    var game = gameAndNumbers.First();
    var numbers = gameAndNumbers[1].Split('|');
    var winningNumbers = numbers[0].Split(' ').Where(x=> !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
    var chosenNumbers = numbers[1].Split(' ').Where(x=> !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();


    foreach (var chosenNumber in chosenNumbers)
    {
        if (winningNumbers.Contains(chosenNumber))
        {
            if (gameScore == 0)
                gameScore++;
            else
                gameScore *= 2;
        }
    }
    games.Add(new Ticket { GameName = game, Score = gameScore });
}

Console.WriteLine(games.Sum(x=> x.Score));
