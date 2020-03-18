using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame{
    class GameView
    {
        internal void clearScreen()
        {
            throw new NotImplementedException();
        }
        internal string displayPlayer(Player activePlayer)
        {
            return ("ActivePlayer:" + activePlayer.Name + "\n");
        }

        internal void waitForSomeInterectionFromPlayer()
        {
            throw new NotImplementedException();
        }

        internal void displayInput(string v)
        {
            System.Console.ReadLine();
        }

        internal void displayCard(Card card)
        {
            System.Console.WriteLine("card");;
        }

        internal void displayTable(List<Card> cards)
        {
            System.Console.WriteLine("tabela");;
        }
    }
}