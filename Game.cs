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

            activePlayer = players[0];
            while (isActive)
            {
                handleRound();
                changeActivePlayer();
            }


        }
        private int choiceFromActivePlayer()
        {
            gameView.displayInput("Select which attribiute You want to play:");
            //try
            //{
                return activePlayer.getChoice();
            //}
            //catch(System.FormatException)
            //{
            //    Console.WriteLine("Invalid Input. You can select only number from 1 to 4");
            //}

        }

        void handleRound()
        {
            
            gameView.displayPlayer(activePlayer);

            assignTopCardsToPlayers();
            
            gameView.displayCard(table.activCards[0]);
            
            //player choice which attribiute is the strongest
            int playerChoice = choiceFromActivePlayer();
            CardAtributte attribute = (CardAtributte)playerChoice;
            
            //roundGame
            CardsComparer Comparator=new CardsComparer(attribute);
            table.comparator = Comparator;
            Player roundWinner=table.GetRoundWinner();
            
            showCards(table.activCards);

            //substract top cards from hand player
            foreach(Player player in players)
            {
                player.Cards.Dequeue();
            }

            //add cards to winner if is
            if (roundWinner != null)
            { 
                foreach(Card elem in table.GetRoundTrophy())
                {
                    roundWinner.Cards.Enqueue(elem);  
                    
                }
                table.activCards.Clear();
                table.cardsAfterDraw.Clear();
            } 
            //if nobody won round game them cards are adding to cardsAfterDraw
            else
            {
                table.MoveActivCardsToAfterDraw();
            }   
            
            //check that one player has all cards
            isOver();
            if(isActive == false)
            {
                gameView.displayEndGame(getWinnerGame());
            }
            table.whoCards.Clear();

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

        private void assignTopCardsToPlayers()
        {
            foreach (Player player in players)
            {
                table.PutCard(player.Cards.Peek(),player);
            }
            
        }

        void showCard(Card card)
        {
            gameView.displayCard(card);
        }

        void showCards(List<Card> cards)
        {
            //gameView.displayTable(cards);
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

        private bool isOver()
        {
            int playersWithoutCards = 0;
            int numberOfPlayers = players.Count;
            foreach(Player player in players){
                if(player.Cards.Count==0){
                    playersWithoutCards++;
                }
                if(playersWithoutCards==numberOfPlayers-1){
                    return isActive = false;
                }
            }
            return isActive = true;
        }

    }
}



