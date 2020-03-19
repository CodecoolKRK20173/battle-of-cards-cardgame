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
                //Console.Clear();
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
            /* Propozycja:
            int cardsOnTable = table.PutCard(player.getTopCard(), activePlayer); //Wyciagnij karte od gracza i poloz na stole

            gameView.DisplayTable(table); //wyswietl zawartosc stolu
            
            List<Card> cardTrophy;
            if cardsOnTable == 2 /NUMBER_OF_PLAYERS then
            {
                List<Card> cardTrophy = table.GetTrophy(); //Sprawdz zwyciezce i zwroc trofeum
                if(cardTrophy != null)
                {
                    table.GetRoundWinner().AddCards(cardTrophy); //Trzeba stworzyc metody w Player AddCards(List<Card> cards)
                }
                else
                {
                    table.MoveActivCardsToAfterDraw();
                }
            }
             */
            assignTopCardsToPlayers();

            //wyświetl karte aktywnego gracza
            gameView.displayCard(table.activCards[0]);
            //spytaj się gracza o atrybut
            int playerChoice = choiceFromActivePlayer();
            //Console.Clear();
            //porownaj karty
            CardAtributte attribute = (CardAtributte)playerChoice;
            CardsComparer Comparator=new CardsComparer(attribute);
            table.comparator = Comparator;
            Player roundWinner=table.GetRoundWinner();
            showCards(table.activCards);
            //metoda dodajaca/odejmujca karty do kupki

            
            // zarzadaj kartami po roztrzygniejtej rozgrywce/ remisie
            table.MoveActivCardsToAfterDraw(); 

            isOver();
            if(isActive == false)
            {
                gameView.displayEndGame(getWinnerGame());
            }

        }

        // metoda dodaje karte wygrana i odejmuje drugiemu

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
            gameView.displayTable(cards);
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



