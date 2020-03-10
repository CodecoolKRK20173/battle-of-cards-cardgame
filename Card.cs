using System.Collections.Generic;
namespace battle_of_cards_cardgame {
    public class Card {

        public int Power { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Coolness { get; set; }
        public string Curiosity { get; set; }
        bool hidden { get; set; }
        public Card (string name, int speed, int power, int coolness, string curiosity) {

            Power = power;
            Name = name;
            Speed = speed;
            Coolness = coolness;
            Curiosity = curiosity;
            hidden = true;
        }

    }
}