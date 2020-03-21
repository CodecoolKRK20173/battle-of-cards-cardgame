using System.Collections.Generic;

namespace battle_of_cards_cardgame{
    class Hand{
        readonly Queue<Card> _cards;
        public Hand(Queue<Card> cards)
        {
            _cards = cards;
        }
        public Card GetTopCard()
        {
            return _cards.Peek();
        }
    }
}