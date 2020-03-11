using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    class HumanPlayer : Player {
        string Name;
        Queue<Card> Cards;
        public HumanPlayer (string name, Queue<Card> cards) {
            Name = name;
            Cards = cards;
        }
    }
}