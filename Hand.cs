using System.Collections.Generic;

namespace battle_of_cards_cardgame{
    class Hand{
        Queue<Card> Cards;
        public Hand( Queue<Card> cards){
            Cards = cards;
        }
         public Card getTopCard(){
            return Cards.Peek();
        }
    }
}