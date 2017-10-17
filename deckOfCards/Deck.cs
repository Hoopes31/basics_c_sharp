using System;
using System.Collections.Generic;

namespace deckOfCards {
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        private string[] suits = {"Spade", "Club", "Diamond", "Heart"};
        private string[] cardFaceValue = {"Ace", "2", "3", "4", "5", "6", "7", 
                            "8", "9", "10", "Jack", "Queen", "King"};

        //Initilize Ace Low Deck
        public Deck() => SetDeckAceLow();

        public Deck(string order)
        {
            if (order == "ace high")
            {
                SetDeckAceHigh();
            }
            else
            {
                SetDeckAceLow();                
            }
        }
        //Deal Topmost Card
        public Card Deal()
        {
            Card deltCard = cards[0];
            cards.RemoveAt(0);
            return deltCard;
        }
        public void SetDeckAceLow()
        {
            foreach (string suit in suits)
            {
                for (int value = 0; value < 13; value++)
                {
                    Card card = new Card();
                    card.suit = suit;
                    card.cardFace = cardFaceValue[value];
                    card.cardValue = value + 1;
                    cards.Add(card);
                }
            }
        }
        public void SetDeckAceHigh()
        {
            foreach (string suit in suits)
            {
                for (int value = 1; value <= 13; value++)
                {
                    Card card = new Card();
                    if (value == 13)
                    {
                        card.suit = suit;
                        card.cardFace = cardFaceValue[0];
                        card.cardValue = value;
                        cards.Add(card);
                    }
                    else
                    {
                    card.suit = suit;
                    card.cardFace = cardFaceValue[value];
                    card.cardValue = value;
                    cards.Add(card);
                    }
                }
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int shift = 0; shift < cards.Count; shift++)
            {
                Card temp = cards[shift];
                int randomSpot = rand.Next(shift, cards.Count);
                cards[shift] = cards[randomSpot];
                cards[randomSpot] = temp;
            }
        }
    }
}