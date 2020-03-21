using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    public abstract class Player {
        
        public string Name { get; private set; }
        public Queue<Card> Cards { get; set; }

        public Player(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
            else
                throw new System.ArgumentException("Name cannot be empty!", nameof(name));
        }
        public abstract int GetChoice ();
    }
}