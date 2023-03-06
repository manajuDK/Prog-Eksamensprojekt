namespace Blazor_Poker_Nights.Shared
{ // made by Marinus + Filip
    public class User
    {
        public string? name { get; set; }
        public int startBalance { get; set; }
        public int currentBalance { get; set; }
        public Card[] hand { get; set; } = new Card[2];

    }

    public class Card
    {
        public string suit { get; set; }
        public int value { get; set; } // 2 -> 14 (hvor 11, 12, 13 er billedkort og 14 er es)

        public Card(string _suit, int _value)
        {
            this.suit = _suit;
            this.value = _value;
        }
    }

    public class Deck
    {
        public List<Card> cards { get; set; }

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "Hearts", "Diamond", "Spades", "Clubs" };
            foreach (string suit in suits)
            {
                for (int i = 2; i < 15; i++) // 2..14
                {
                    cards.Add(new Card(suit, i));
                }
            }
        }

    }



    public static class GlobalInfo
    {
        static public List<User> userList { get; set; } = new List<User>();
        static public int rounds { get; set; } = 0;


    }


}
