using System;
using System.Collections.Generic;
using System.Text;

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
        internal string displayEndGame(Player playerWinner)
        {
            return ("The game win: " + playerWinner);
        }

        internal void waitForSomeInterectionFromPlayer()
        {
            throw new NotImplementedException();
        }

        internal void displayInput(string v)
        {
            System.Console.ReadLine();
        }

        public void displayCard(Card card) 
        {
            Console.WriteLine("Card");
        }
        /*public String centeredString(String text) 
        {
            int widthColumn = 35;
            int padSize = widthColumn - text.length();
            int padStart = text.length() + padSize / 2;
            text = String.format("%" + padStart + "s", text);
            text = String.format("%-" + widthColumn  + "s", text);

            return text;
        }*/

        internal void displayTable(List<Card> cards)
        {
            System.Console.WriteLine("tabela");;
        }
    }
}