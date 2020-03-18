using System;
using System.Collections.Generic;
// using Player;
// using Table;
// using GameView;


namespace battle_of_cards_cardgame
{

    public class Game
    {
        private List<Player> players { get; set; }
        private Player activePlayer { get; set; }
        private bool isActive { get; set; }
        private GameView gameView { get; set; }
        private Table table { get; set; }



        public Game(List<Player> Players)
        {
            players = Players;
            isActive = true;
            gameView = new GameView();
            table = new Table();
            play();

        }

        public void play()
        {

            // gameView.clearScreen(); not implemented yet
            activePlayer = players[0];
            while (isActive)
            {
                // gameView.clearScreen(); // not implemented yet
                handleRound();
                changeActivePlayer();
                //metoda to gameVie for instance player has to press enter and then game over or sth other..
                // gameView.waitForSomeInterectionFromPlayer() //not implemented yet
            }


        }
        private int choiceFromActivePlayer()
        {
            while (true)
            {
                //Aneta - metoda w gameView displayInput
                gameView.displayInput("Select which attribiute You want to play:");
                //w playerze metoda getChoice
                return activePlayer.getChoice();
            }
        }

        void handleRound()
        {
            gameView.displayPlayer(activePlayer);
            //pobierz pierwsze karty z góry od graczy
            List<Card> activeCards = getTopCards();
            //wyświetl karte aktywnego gracza
            gameView.displayCard(activeCards[0]);
            //spytaj się gracza o atrybut
            //wyswietl karte nieaktywnego gracza
            //porowna karty
            //znajdz gracz ktory wygral
            // wysietl komunikat ktory gracz wygrał/przegrał/ remis
            // zarzadaj kartami po roztrzygniejtej rozgrywce/ remisie
            //zmien aktywnego gracza


        }

        private void changeActivePlayer()
        {
            if(activePlayer== players[0])
            {
                activePlayer = players[1];
            }
            else{
                activePlayer = players[0];
            }
        }

        private List<Card> getTopCards()
        {
            List<Card> activeCards = new List<Card>();
            foreach (Player player in players)
            {
                activeCards.Add(player.Cards.Peek());
            }
            return activeCards;
        }



        void showCard(Card card)
        {
            gameView.displayCard(card);
        }

        void showCards(List<Card> cards)
        {
            gameView.displayTable(cards);
        }

        void checkIfWon()
        {

        }
        // Player getWinner()
        // {

        // }

        void getAttribiuteToCompare()
        {

        }

    }
}



