using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    public class GameSetup {
        public int NumberOfPlayers { get; set; }
        public List<string> Names = new List<string> ();

        public GameSetup () {
            NumberOfPlayers = getNumbersOfPlayers ();
            getPlayersNames ();
            Deck deck = new Deck (new CardDAO ("cars.csv"));
            deck.GetAllCards ();
            List<Queue<Card>> pilesOfCards = deck.randCards (NumberOfPlayers);
        }

        private void getPlayersNames () {
            // string name;
            for (int i = 0; i < NumberOfPlayers; i++) {
                // System.Console.WriteLine ("Player {0}. Type your nick: ", i + 1);
                // name = System.Console.ReadLine ();
                // Names.Add (name); // odkomentować dla poprawnego działania
                Names.Add ("Bob");
                Names.Add("James");

            }
        }

        private int getNumbersOfPlayers () {
            return 2;
        }
    }
}