using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame
{
    class GameView
    {
        private static int width = 30;
        private void clearScreen()
        {
            Console.Clear();
        }
        public int getNumbersOfPlayers()
        {
            Console.Clear();
            Console.WriteLine("Game modes:\n");
            Console.WriteLine("1. Player vs Computer");
            Console.WriteLine("2. Player vs Player \n");

            Console.Write("Your choice: ");
            string input = System.Console.ReadLine();
            int gameMode;
            while (int.TryParse(input, out gameMode) == false | int.Parse(input) != 2)
            {
                Console.WriteLine("Invalid choice!. For now Player vs Player only available");
                System.Console.Write("Please try again: ");
                input = System.Console.ReadLine();
            }
            return gameMode;

        }
        public List<string> getPlayersNames(int numberOfPlayers)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                System.Console.WriteLine("Player {0}. Type your nick: ", i + 1);
                string name = System.Console.ReadLine();
                names.Add(name); // odkomentować dla poprawnego działania
            }
            return names;
        }
        public void displayPlayer(Player activePlayer)
        {
            System.Console.WriteLine(activePlayer.Name + " turn\n");
        }
        public string displayEndGame(Player playerWinner)
        {
            return ("The game win: " + playerWinner);
        }

        public void displayInput(string message)
        {
            Console.WriteLine(message);
        }

        public void displayCard(Card card, Player activePlayer)
        {
            clearScreen();
            string activePlayerName = string.Format("Current player:{0}\n", activePlayer.Name);
            Console.WriteLine(CenteredString(activePlayerName, width));

            List<Card> tempList = new List<Card>();
            tempList.Add(card);
            string[] cardView = CardsView(tempList, width);

            foreach (string s in cardView)
            {
                Console.WriteLine(CenteredString(s, width));
            }
        }
        static string CenteredString(string s, int width)
        {
            if (s.Length >= width)
            {
                return s;
            }

            int leftPadding = (width - s.Length) / 2;
            int rightPadding = width - s.Length - leftPadding;

            return new string(' ', leftPadding) + s + new string(' ', rightPadding);
        }


        public void displayTable(Table table, CardAtributte atr, Player activePlayer)
        {
            clearScreen();
            int cardWidth = 30;
            int tableWidth = cardWidth * Math.Max(table.activCards.Count, table.cardsAfterDraw.Count);
            string tableView = "---------- TABLE ----------";
            tableView = CenteredString(tableView, tableWidth);
            string playerTurn = string.Format("--------{0} Turn-----------", activePlayer.Name);
            playerTurn = CenteredString(playerTurn, tableWidth);
            string selectedAtr = "SELECTED ATRTRIBUTE: " + atr.ToString().ToUpper();
            selectedAtr = CenteredString(selectedAtr, tableWidth);
            string winningPlayer;
            if (table.winningPlayer != null)
            {
                winningPlayer = string.Format("-------{0} wins---------", table.winningPlayer.Name);
            }
            else
            {
                winningPlayer = "-------It`s a draw-----------";
            }


            winningPlayer = CenteredString(winningPlayer, tableWidth);

            string[] activCardsView = CardsView(table.activCards, cardWidth);
            string[] cardsAfterDrawView = CardsView(table.cardsAfterDraw, cardWidth);

            //printing to console
            Console.WriteLine(tableView);
            Console.WriteLine(playerTurn);
            Console.WriteLine(selectedAtr);
            Console.WriteLine(winningPlayer + "\n");
            if (table.activCards.Count > 0)
            {
                foreach (string e in activCardsView)
                {

                    Console.WriteLine(CenteredString(e, tableWidth));
                }
            }

            Console.WriteLine();
            if (table.cardsAfterDraw.Count > 0)
            {
                Console.WriteLine(CenteredString("CARDS FROM DRAW:\n", tableWidth));
            }

            if (table.cardsAfterDraw.Count > 0)
            {
                foreach (string e in cardsAfterDrawView)
                {
                    Console.WriteLine(CenteredString(e, tableWidth));
                }
            }
            System.Console.ReadLine();


        }

        public string[] CardsView(List<Card> cards, int cardWidth)
        {
            string[] cardsView = new string[6];
            foreach (Card c in cards)
            {
                string format = "{0, -" + cardWidth + "}";
                cardsView[0] += String.Format(format, "\t " + c.Name);
                cardsView[1] += String.Format(format,
                                "\t| - - - | 1. Power=" + c.CardDetails[CardAtributte.Power].ToString());
                cardsView[2] += String.Format(format, "\t|       |");
                cardsView[3] += String.Format(format,
                                "\t|       | 2. Speed=" + c.CardDetails[CardAtributte.Speed].ToString());
                cardsView[4] += String.Format(format, "\t|       |");
                cardsView[5] += String.Format(format,
                                "\t| - - - | 3. Cool=" + c.CardDetails[CardAtributte.Coolness].ToString());
            }
            return cardsView;

        }
    }
}