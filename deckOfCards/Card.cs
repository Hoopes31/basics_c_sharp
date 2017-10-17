namespace deckOfCards {

    public class Card
    {
        private string _cardFace;
        public string cardFace 
        {
            get { return _cardFace; } 
            set { _cardFace = value; }
        }
        private string _suit;
        public string suit 
        {
            get { return _suit; } 
            set { _suit = value; }
        }
        private int _cardVal;
        public int cardValue 
        {
            get { return _cardVal; } 
            set { _cardVal = value; }
        }

    }
}