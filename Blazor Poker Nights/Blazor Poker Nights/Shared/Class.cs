namespace Blazor_Poker_Nights.Shared
{ // Lavet af Filip + Marinus i fællesskab
    public class User
    {
        public string name { get; set; } = "";
        public int startBalance { get; set; } = 500;
        public int currentBalance { get; set; } = 500;
        public Card[] hand { get; set; } = new Card[2];

        //game information:
        public Boolean active { get; set; } = false;
        public int runningBalance()
		{
            return currentBalance - startBalance;
        }

        public int currentBet { get; set; } = 0; // den her runde
        public int[] bestHand { get; set; } = new int[2];
        public void bet(int amount)
        {
            currentBalance -= amount;
            currentBet += amount;
        }

    }

    public class Card
    {
        public string suit { get; set; }
        public int value { get; set; } // 1 -> 13 (hvor 11, 12, 13 er billedkort og 1 er es)

        public Card(string _suit, int _value)
        {
            this.suit = _suit;
            this.value = _value;
            
        }

        public string getName()
		{
            string link = "svg-cards.svg#";
            link += this.suit + "_";
			if (value > 10)
            {
                string[] nameArray = { "jack", "queen", "king" };
                link += nameArray[value - 11];
            }
            else
            {
                link += this.value.ToString();
            }
            return link;
        }

    }

    public class Deck
    {
        public List<Card> cards { get; set; }

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = { "heart", "diamond", "spade", "club" };
            foreach (string suit in suits)
            {
                for (int i = 1; i < 14; i++) // 1..13
                {
                    cards.Add(new Card(suit, i));
                }
            }
        }

        public Card draw()
        {
            Random rand = new Random();
            int idx = rand.Next(0, cards.Count - 1);
            Card chosen = this.cards[idx];
            this.cards.RemoveAt(idx);
            return chosen;
        }

    }



    public static class GlobalInfo
    {
        static public List<User> userList { get; set; } = new List<User>();
        static public int rounds { get; set; } = 0;
    }


}
