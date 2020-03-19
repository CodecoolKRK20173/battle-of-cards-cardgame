using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    public abstract class Player {
        public string Name { get; set; }
        public Queue<Card> Cards { get; set; }

<<<<<<< HEAD
        protected abstract int getChoice ();
=======
        public abstract int getChoice ();
>>>>>>> feature/Game
    }
}