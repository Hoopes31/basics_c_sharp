using System;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Bob = new Player();
            Bob.name = "Bob";
            System.Console.WriteLine(Bob.name);
            Deck deck = new Deck("ace high");
            deck.Shuffle();
            System.Console.WriteLine(deck.cards[0].cardValue);
        }
    }
}
