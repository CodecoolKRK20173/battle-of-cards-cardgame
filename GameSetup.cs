using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    public class GameSetup {

        public Deck deck { get; set; }
        List<Player> players = new List<Player> ();
        GameView gameView = new GameView();
        public GameSetup () {
            CreateDeck ();
            CreatePlayers ();
            Game game = new Game(players);
        }

        private void CreatePlayers ()
        {
            int NumberOfPlayers = gameView.getNumbersOfPlayers();
            List<string> names = gameView.getPlayersNames(NumberOfPlayers);
            List<Queue<Card>> pilesOfCards = deck.dealCards(NumberOfPlayers);
            makeInstanceOfPlayer(NumberOfPlayers, names, pilesOfCards);
        }

        private void makeInstanceOfPlayer(int NumberOfPlayers, List<string> names, List<Queue<Card>> pilesOfCards)
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Player humanPlayer = new HumanPlayer(names[i], pilesOfCards[i]);
                players.Add(humanPlayer);
            }
        }

        private void CreateDeck () {
            deck = new Deck (new CardDAO ("cars.csv"));
        }
    }
}