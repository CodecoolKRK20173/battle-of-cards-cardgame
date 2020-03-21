using System;
using System.Collections.Generic;
using System.IO;

namespace battle_of_cards_cardgame {
    public class GameSetup {

        Deck _deck;
        List<Player> _players = new List<Player> ();
        GameView _gameView = new GameView();
        public GameSetup () 
        {
            try
            {
                CreateDeck ();
                CreatePlayers ();
                Game game = new Game(_players); 
            }
            catch (InvalidDataException exc)
            {
                View.DisplayMessage(exc.Message);
                View.WaitForEnter();
            }
        }

        private void InitializePlayers()
        {

            
        }

        private void CreatePlayers ()
        {
            View.ClearScreen();
            List<string> names = new List<string>();

            int numberOfPlayers = _gameView.GetNumbersOfPlayers();
            List<Queue<Card>> pilesOfCards = _deck.DealCards(numberOfPlayers);

            while(names.Count == 0)
            {
                try
                {
                    names = _gameView.GetPlayersNames(numberOfPlayers);
                    CreateInstancesOfHumanPlayers(numberOfPlayers, names, pilesOfCards);
                }
                catch (InvalidOperationException)
                {
                    names = new List<string>();
                    View.DisplayMessage("Name cannot be empty!");
                    View.WaitForEnter();
                }
            }
        }

        private void CreateInstancesOfHumanPlayers(int numberOfPlayers, List<string> names, List<Queue<Card>> pilesOfCards)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                try
                {
                    Player humanPlayer = new HumanPlayer(names[i], pilesOfCards[i]);
                    _players.Add(humanPlayer);    
                }
                catch (ArgumentException)
                {
                    throw new InvalidOperationException("Name cannot be empty!");
                }
            }
        }

        private void CreateDeck () 
        {
            try
            {
                _deck = new Deck (new CardDAO ("cars.xml"));
            }
            catch (InvalidDataException)
            {
                throw;
            }
            
        }
    }
}