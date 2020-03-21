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
            View.DisplayMessage("\n      Your choice: ");
            int choice = 0;
            var validAnswers = new List<int>() { 1, 2, 3};
            while (!validAnswers.Contains(choice))
                try
                {
                    choice = Int32.Parse(View.WaitForString());
                    if (!validAnswers.Contains(choice)) throw new ArgumentException();
                }
                catch (FormatException)
                {
                    View.DisplayLine("Wrong input. Please enter a value '1', '2' or  '3'.");

                }
                catch (ArgumentException)
                {
                    View.DisplayLine("Please enter a number from range 1-3");
                }
            return choice;
        }

        // public override void getChoice () 
        // {
        //     System.Console.WriteLine("T");
        // }
    }
}