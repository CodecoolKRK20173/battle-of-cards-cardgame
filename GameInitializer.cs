using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    public class GameInitializer {

        public Deck deck { get; set; }
        List<Player> players = new List<Player> ();
        public GameInitializer () {
            CreateDeck ();
            CreatePlayers ();
<<<<<<< HEAD
=======
            Game game = new Game(players);
>>>>>>> feature/Game
        }

        private void CreatePlayers ()
        {
            int NumberOfPlayers = getNumbersOfPlayers();
            List<string> names = getPlayersNames(NumberOfPlayers);
            List<Queue<Card>> pilesOfCards = deck.dealCards(getNumbersOfPlayers());
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

        private List<string> getPlayersNames (int numberOfPlayers) {
            List<string> names = new List<string> ();
            for (int i = 0; i < numberOfPlayers; i++) {
                // System.Console.WriteLine ("Player {0}. Type your nick: ", i + 1);
                // name = System.Console.ReadLine ();
                // Names.Add (name); // odkomentować dla poprawnego działania
                names.Add ("Bob");
            }
            return names;
        }

        private int getNumbersOfPlayers () {
            return 2;
        }
    }
}