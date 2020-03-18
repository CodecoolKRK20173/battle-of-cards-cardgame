using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame
{
    public class Card : IComparable<Card>
    {
        public int index {get; private set;}
        public Card(int speed, int power, int horses, int capacity, string model)
        {
            Console.WriteLine("Hello World");
        }
    }
}