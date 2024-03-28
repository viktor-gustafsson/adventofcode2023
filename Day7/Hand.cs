namespace Day7;

public class Hand : IComparable<Hand>
{
    public int Bet { get; set; }
    public List<Card> Cards { get; set; }
    public Type Type { get; set; }
    
    public int CompareTo(Hand other)
    {
        if (Type != other.Type)
        {
            return Type.CompareTo(other.Type);
        }

        for (var i = 0; i < Cards.Count; i++)
        {
            if (Cards[i].Value != other.Cards[i].Value)
            {
                return Cards[i].Value.CompareTo(other.Cards[i].Value);
            }
        }

        return 0;
    }
}