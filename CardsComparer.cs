using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame
{
    public class CardsComparer : IComparer<Card>
    {
        private CardAtributte Feature { get; set; }

        public CardsComparer(CardAtributte feature)
        {
            Feature = feature;
        }

        int IComparer<Card>.Compare(Card firstCard, Card secondCard)
        {
            if (firstCard.CardDetails[Feature] > secondCard.CardDetails[Feature])
            {
                return 1;
            }
            else if (firstCard.CardDetails[Feature] < secondCard.CardDetails[Feature])
            {
                return -1;
            }
            return 0;
        }
    }
}