using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame
{
    public class CardsComparer : IComparer<Card>
    {
        public CardAtributte feature;

        public CardsComparer(CardAtributte feature)
        {
            this.feature = feature;
        }
        int IComparer<Card>.Compare(Card first, Card second)
        {
            if (first.CardDetails[feature] > second.CardDetails[feature])
            {
                return 1;
            }
            else if (first.CardDetails[feature] < second.CardDetails[feature])
            {
                return -1;
            }
            return 0;
        }
    }
}