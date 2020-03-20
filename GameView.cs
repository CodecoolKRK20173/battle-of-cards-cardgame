using System;
using System.Collections.Generic;
using System.Text;

namespace battle_of_cards_cardgame{
    class GameView
    {
        void clearScreen()
        {
            Console.Clear();
        }
        public string displayPlayer(Player activePlayer)
        {
            return ("ActivePlayer:" + activePlayer.Name + "\n");
        }
        public string displayEndGame(Player playerWinner)
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

        public void displayCard(Card card) 
        {
            Console.WriteLine("Card");
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
        

        public  void displayTable(Table table, CardAtributte atr )
        {
            int cardWidth = 30;
            int tableWidth = cardWidth * Math.Max(table.activCards.Count, table.cardsAfterDraw.Count);
            string tableView = "---------- TABLE ----------";
            tableView = CenteredString(tableView, tableWidth);
            string selectedAtr = "SELECTED ATRTRIBUTE: " + atr.ToString().ToUpper() ;
            selectedAtr = CenteredString(selectedAtr, tableWidth);
            string[] activCardsView = CardsView(table.activCards, cardWidth);
            string[] cardsAfterDrawView = CardsView(table.cardsAfterDraw, cardWidth);

            //printing to console
            Console.WriteLine(tableView);
            Console.WriteLine(selectedAtr + "\n");
            if(table.activCards.Count > 0)
            {
                foreach(string e in activCardsView)
                {
                    Console.WriteLine(CenteredString(e, tableWidth));
                }
            }

            Console.WriteLine();
            Console.WriteLine(CenteredString("CARDS FROM DRAW:\n", tableWidth));
            if(table.cardsAfterDraw.Count > 0)
            {
                foreach(string e in cardsAfterDrawView)
                {
                    Console.WriteLine(CenteredString(e, tableWidth));
                }
            }


        }

        public string[] CardsView(List<Card> cards, int cardWidth)
        {
            string[] cardsView = new string[6];
            foreach(Card c in cards)
            {
                string format = "{0, -" + cardWidth + "}";
                cardsView[0] += String.Format(format, "\t " + c.Name);
                cardsView[1] += String.Format(format, 
                                "\t| - - - | Pow=" + c.CardDetails[CardAtributte.Power].ToString());
                cardsView[2] += String.Format(format, "\t|       |");
                cardsView[3] += String.Format(format, 
                                "\t|       | Speed=" + c.CardDetails[CardAtributte.Speed].ToString());
                cardsView[4] += String.Format(format, "\t|       |");
                cardsView[5] += String.Format(format, 
                                "\t| - - - | Cool=" + c.CardDetails[CardAtributte.Coolness].ToString());
            }
            return cardsView;

        }
    }
}