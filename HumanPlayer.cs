using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame
{
    class HumanPlayer : Player
    {

        public HumanPlayer(string name, Queue<Card> cards)
        {
            Name = name;
            Cards = cards;
            Hand HumanPlayerHand = new Hand(cards);
        }

        public override int getChoice()
        {
            System.Console.Write("\n      Your choice: ");
            int choice = 0;
            List<int> ValidAnswers = new List<int>() { 1, 2, 3, 4 };
            while (!ValidAnswers.Contains(choice))
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (!ValidAnswers.Contains(choice)) throw new ArgumentException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input.Please enter a value '1', '2', '3', or '4'.");

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter number from range 1-4");
                }
            return choice;
        }

        // public override void getChoice () {
        //     System.Console.WriteLine("T");
        // }
    }
}