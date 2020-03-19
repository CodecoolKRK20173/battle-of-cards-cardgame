using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame{
    class GameView
    {
        void clearScreen()
        {
            Console.Clear();
        }
        string displayPlayer(Player activePlayer)
        {
            return ("ActivePlayer:" + activePlayer.Name + "\n");
        }
        string displayEndGame(Player playerWinner)
        {
            return ("The game win: " + playerWinner);
        }

        void waitForSomeInterectionFromPlayer()
        {
            throw new NotImplementedException();
        }

        public void displayInput(string message)
        {   
            //czy ta metoda powinna pobierac input uzytkownika ?
            Console.WriteLine(message);
            Console.WriteLine("You can select from below attributes");
            foreach(var a in Enum.GetNames(typeof(CardAtributte)))
            {
                Console.WriteLine(a);
            }
            //System.Console.ReadLine();

        }

        internal void displayCard(Card card)
        {
            System.Console.WriteLine("card");;
        }

        internal void displayTable(List<Card> cards)
        {
            System.Console.WriteLine("tabela");
        }
    }
}