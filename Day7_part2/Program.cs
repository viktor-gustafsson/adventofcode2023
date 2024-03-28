using Day7_part2;
using Type = Day7_part2.Type;

var charToCardMap = new Dictionary<char, Value>
{
    { 'J', Value.Joker },
    { '2', Value.Two},
    { '3', Value.Three},
    { '4', Value.Four},
    { '5', Value.Five },
    { '6', Value.Six },
    { '7', Value.Seven },
    { '8', Value.Eight },
    { '9', Value.Nine },
    { 'T', Value.Ten },
    { 'Q', Value.Queen },
    { 'K', Value.King },
    { 'A', Value.Ace }
};

var handsAndBets = File.ReadLines("C:\\develop\\AdventOfCode2023\\Day7_part2\\input.txt");
var hands = new List<Hand>();

foreach (var handAndBet in handsAndBets)
{
    var handAndBetSplit = handAndBet.Split(' ');
    var hand = new Hand
    {
        Bet = int.Parse(handAndBetSplit[1]),
        Cards = []
    };

    foreach (var card in handAndBetSplit[0])
    {
        hand.Cards.Add(new Card
        {
            Value = charToCardMap[card]
        });
    }

    var jokers = hand.Cards.Count(x=>x.Value == Value.Joker);
    var groupBy = hand.Cards.Where(card => card.Value != Value.Joker).Select(x => x.Value).GroupBy(x => x)
        .OrderByDescending(x => x.Count())
        .Select(x => x.Count())
        .ToList();

    int cardCount;

    if (jokers == 5)
        cardCount = 5;
    else
        cardCount= groupBy[0]+jokers;

    hand.Type = cardCount switch
    {
        5 => Type.FiveOfAKind,
        4 => Type.FourOfAKind,
        3 when groupBy[1] == 2 => Type.FullHouse,
        3 when groupBy[1] == 1 => Type.ThreeOfAKind,
        2 when groupBy[1] == 2 => Type.TwoPair,
        2 => Type.OnePair,
        _ => Type.HighCard
    };
    
    hands.Add(hand);
}


hands.Sort();

var result = 0;
for (var i = 0; i < hands.Count; i++)
{
    result += hands[i].Bet * (i + 1);
}

Console.WriteLine(result);