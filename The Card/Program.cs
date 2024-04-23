
foreach (CardColour colour in Enum.GetValues(typeof(CardColour)))
{
    foreach(CardRank rank in Enum.GetValues(typeof(CardRank)))
    {
        Card card = new Card(colour, rank);
        Console.WriteLine($"The {card.Colour} {card.Rank}");
    }
}


class Card
{
    public CardColour Colour { get; private set; }
    public CardRank Rank { get; private set; }

    public CardRankType RankType
    {
        get
        {
            if (Rank == CardRank.DollarSign || Rank == CardRank.Percent || Rank == CardRank.Caret || Rank == CardRank.Ampersand) return CardRankType.Symbol;
            else return CardRankType.Number;
        }

    }

    public Card(CardColour colour, CardRank rank)
    {
        Colour = colour;
        Rank = rank;
    }
}


enum CardColour { Red, Green, Blue, Yellow }
enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }
enum CardRankType { Number, Symbol }