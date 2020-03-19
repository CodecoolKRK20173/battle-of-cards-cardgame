using System.Collections.Generic;
namespace battle_of_cards_cardgame {
    public class Card {

        public string Name { get; set; }
        public string Curiosity { get; set; }
        // public int Power { get; set; }
        // public int Speed { get; set; }
        // public int Coolness { get; set; }

        public bool hidden { get; set; }
        public Dictionary<CardAtributte, int> CardDetails=new Dictionary<CardAtributte, int>();
        public Card (string name, int power, int speed, int coolness, string curiosity) {
            Name = name;
            Curiosity = curiosity;
            CardDetails[CardAtributte.Power] = power;
            CardDetails[CardAtributte.Speed] = speed;
            CardDetails[CardAtributte.Coolness] = coolness;
        }


    }
}