using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    class HumanPlayer : Player {

        public HumanPlayer (string name, Queue<Card> cards) {
            Name = name;
            Cards = cards;
            Hand HumanPlayerHand=new Hand(cards);
        }

<<<<<<< HEAD
        protected override int getChoice () {
=======
        public override int getChoice () {
>>>>>>> feature/Game
            System.Console.WriteLine ("Your choice: ");
            int choice = int.Parse (System.Console.ReadLine ());
            return choice;
        }

        // public override void getChoice () {
        //     System.Console.WriteLine("T");
        // }
    }
}