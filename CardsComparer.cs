using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame
{
    public class CardsComparer : IComparer<Card>
    {
        public cardsEnums feature;
        
        public CardsComparer(cardsEnums feature)
        {
            this.feature = feature;
        }
        int IComparer<Card>.Compare(Card first, Card second)
        {
            if (first[feature] > second[feature])
            {
                return 1;
            }
            else if (first[feature] < second[feature])
            {
                return -1;
            }
            return 0;
        }
    }