using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame
{
    class GameView : View
    {
        private static int width = 30;

        public int GetNumbersOfPlayers()
        {
            
            int gameMode = 0;
            string input;
            var validAnswers = new List<int>() { 1, 2 };

            View.DisplayMessage(
@"Game modes:
1. Player vs Computer (currently not available)
2. Player vs Player

Your choice: "
            );

            while (!validAnswers.Contains(gameMode))
            {
                input = View.WaitForString();
                try
                {
                    gameMode = Int32.Parse(input);
                    if (!validAnswers.Contains(gameMode)) 
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)
                {
                    View.DisplayLine("\nWrong input. Please enter a value '1' or '2'.");

                }
                catch (ArgumentException)
                {
                    View.DisplayLine("\nPlease enter a number from range 1-2");
                }
            }
            return gameMode;
        }
        public List<string> GetPlayersNames(int numberOfPlayers)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                View.DisplayLine($"\nPlayer {i + 1}. Type your nick: ");
                string name = View.WaitForString();
                names.Add(name); // odkomentować dla poprawnego działania
            }
            return names;
        }
        public void DisplayPlayer(Player activePlayer)
        {
            View.DisplayLine($"{activePlayer.Name} turn\n");
        }
        public string DisplayEndGame(Player playerWinner)
        {
            return ($"And the winner is... {playerWinner}!");
        }

        public void DisplayCard(Card card, Player activePlayer)
        {
            ClearScreen();
            string activePlayerName = string.Format("Current player:{0}\n", activePlayer.Name);
            View.DisplayLine(CenteredString(activePlayerName, width));

            List<Card> tempList = new List<Card>();
            tempList.Add(card);
            string[] cardView = CardsView(tempList, width);

            foreach (string s in cardView)
            {
                View.DisplayLine(CenteredString(s, width));
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


        public void DisplayTable(Table table, CardAtributte atr, Player activePlayer)
        {
            ClearScreen();
            int cardWidth = 30;
            int tableWidth = cardWidth * Math.Max(table.ActiveCards.Count, table.CardsAfterDraw.Count);
            string tableView = "---------- TABLE ----------";
            tableView = CenteredString(tableView, tableWidth);
            string playerTurn = string.Format("--------{0} Turn-----------", activePlayer.Name);
            playerTurn = CenteredString(playerTurn, tableWidth);
            string selectedAtr = "SELECTED ATRTRIBUTE: " + atr.ToString().ToUpper();
            selectedAtr = CenteredString(selectedAtr, tableWidth);
            string winningPlayer;
            if (table.WinningPlayer != null)
            {
                winningPlayer = string.Format("-------{0} wins---------", table.WinningPlayer.Name);
            }
            else
            {
                winningPlayer = "-------It`s a draw-----------";
            }


            winningPlayer = CenteredString(winningPlayer, tableWidth);

            string[] activCardsView = CardsView(table.ActiveCards, cardWidth);
            string[] cardsAfterDrawView = CardsView(table.CardsAfterDraw, cardWidth);

            //printing to console
            View.DisplayLine(tableView);
            View.DisplayLine(playerTurn);
            View.DisplayLine(selectedAtr);
            View.DisplayLine(winningPlayer + "\n");
            if (table.ActiveCards.Count > 0)
            {
                foreach (string e in activCardsView)
                {

                    View.DisplayLine(CenteredString(e, tableWidth));
                }
            }

            View.DisplayLine();
            if (table.CardsAfterDraw.Count > 0)
            {
                View.DisplayLine(CenteredString("CARDS FROM DRAW:\n", tableWidth));
            }

            if (table.CardsAfterDraw.Count > 0)
            {
                foreach (string e in cardsAfterDrawView)
                {
                    View.DisplayLine(CenteredString(e, tableWidth));
                }
            }
            View.WaitForString();


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