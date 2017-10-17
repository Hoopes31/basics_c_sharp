using System.Collections.Generic;
namespace deckOfCards{
    public class Player
    {
        private string _name;
        public string name { 
            get { return _name; }
            set { _name = value; }  
        }
        public Deck deck = new Deck();
        public List<Card> hand = new List<Card>();
        public Card Draw()
        {
            hand.Add(deck.Deal());
            return hand[hand.Count];
        }
        public object Discard(int idx)
        {
            object removedCard = hand[idx];
            hand.RemoveAt(idx);
            return removedCard;
        }
    }
}

