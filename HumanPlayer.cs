using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame
{
    class HumanPlayer : Player
    {

        public HumanPlayer(string name, Queue<Card> cards) : base(name)
        {
            Cards = cards;
            Hand HumanPlayerHand = new Hand(cards);
        }

        public override int GetChoice()
        {
            System.Console.Write("\n      Your choice: ");
            int choice = 0;
            var validAnswers = new List<int>() { 1, 2, 3, 4 };
            while (!validAnswers.Contains(choice))
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (!validAnswers.Contains(choice)) throw new ArgumentException();
                }
                catch (FormatException)
                {
                    View.DisplayMessage("Wrong input. Please enter a value '1', '2', '3', or '4'.");

                }
                catch (ArgumentException)
                {
                    View.DisplayMessage("Please enter a number from range 1-4");
                }
            return choice;
        }

        // public override void getChoice () 
        // {
        //     System.Console.WriteLine("T");
        // }
    }
}