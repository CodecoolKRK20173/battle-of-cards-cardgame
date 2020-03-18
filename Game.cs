using System;
using System.Collections.Generic;
using Player;
using Table;
using GameView;


namespace battle_of_cards_cardgame {

    public class Game
    {
        private List<Player> players{get; set;}
        private Player activPlayer{get; set;}
        private boolean isActive{get; set;}
        private GameView gameView{get; set;}
        private Table table {get; set;}

    

        public Game(List<Player> Players)
        {   
            players = Players;
            isActive = false;
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
                //method gameView for instance player has to press enter and then game over or sth other..
                gameView.waitForSomeInterectionFromPlayer();
            }
           

        }
        private int choiceFromActivePlayer()
        {
            while(true)
            {
                //Aneta - method in gameView displayInput
                gameView.displayInput("Select which attribiute You want to play:");
                return activPlayer.getChoice();
            }
        }

        void handleRound()
        {
            //Player who is active peeks his top card 
            //some method print want we want
            gameView.display("ActivePlayer: " + activPlayer.Name + "\n");
            Card activePlayerTopCards = activPlayer.Cards.Peek();
            showCard(activePlayerTopCards);

            //Active player chooses the best attribute
            int playerChoice = choiceFromActivePlayer();
            table.
            gameView.clearScreen();

            //Top Cards players are gathered


            //show player choice


            //one game is being resolved
            

            //top cards players show

            
            isOver();
            if(isActive == true)
            {
                gameView.displayEndGame(getWinnerGame());
            }

        }

        void showCard (Card card)
        {
            gameView.displayCard(card);
        }

        void showCards (List<Card> cards)
        {
            gameView.displayTable(cards);
        }

        private bool isOver()
        {
            int playersWithoutCards = 0;
            int numberOfPlayers = players.Count;
            foreach(Player player in players){
                if(player.Cards.Count==0){
                    playersWithoutCards++;
                }
                if(playersWithoutCards==numberOfPlayers-1){
                    return isActive = true;
                }
            }
            return isActive = false;
        }

            
        Player getWinnerRound()
        {
            //method which return card of winner player
            return table.GetRoundWinner();
        }

        Player getWinnerGame()
        {
            Player winner=null;
            foreach(Player player in players){
                if(player.Cards.Count>0){
                    winner= player;
                }
            }
            return winner;
        }


    }


}
