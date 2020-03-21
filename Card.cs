using System.Collections.Generic;
namespace battle_of_cards_cardgame 
{
    public class Card 
    {    
        public string Name { get; set; }
        public Dictionary<CardAtributte, int> CardDetails=new Dictionary<CardAtributte, int>();
        private string _curiosity;
        public Card (string name, int power, int speed, int coolness, string curiosity) 
        {
            Name = name;
            _curiosity = curiosity;
            CardDetails[CardAtributte.Power] = power;
            CardDetails[CardAtributte.Speed] = speed;
            CardDetails[CardAtributte.Coolness] = coolness;
        }


    }
}