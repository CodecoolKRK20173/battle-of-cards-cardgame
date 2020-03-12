using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    class HumanPlayer : Player {

        public HumanPlayer (string name, Queue<Card> cards) {
            Name = name;
            Cards = cards;
        }

        protected override int getChoice () {
            System.Console.WriteLine ("Your choice: ");
            int choice = int.Parse (System.Console.ReadLine ());
            return choice;
        }

        // public override void getChoice () {
        //     System.Console.WriteLine("T");
        // }
    }
}