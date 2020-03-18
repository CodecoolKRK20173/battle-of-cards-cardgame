using System;
using System.Collections.Generic;
// using Player;
// using Table;
// using GameView;


namespace battle_of_cards_cardgame {

    public class Game
    {
        private List<Player> players{get; set;}
        private Player activPlayer{get; set;}
        private bool isActive{get; set;}
        private GameView gameView{get; set;}
        private Table table {get; set;}

    

        public Game(List<Player> Players)
        {
            compartor = new CardsComparer();
            players = Players;
            isActive = true;
            table = new Table();
            gameView = new GameView();

        }

        public void play()
        {
            
            gameView.clearScreen();
            activPlayer = players[0];
            while (isActive)
            {
                gameView.clearScreen();
                handleRound();
                //metoda to gameVie for instance player has to press enter and then game over or sth other..
                gameView.waitForSomeInterectionFromPlayer();
            }
           

        }
        private int choiceFromActivePlayer()
        {
            while(true)
            {
                //Aneta - metoda w gameView displayInput
                gameView.displayInput("Select which attribiute You want to play:");
                //w playerze metoda getChoice
                return activPlayer.getChoice();
            }
        }

        void handleRound()
        {
            
        }

        void showCard (Card card)
        {
            gameView.displayCard(card);
        }

        void showCards (List<Card> cards)
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
