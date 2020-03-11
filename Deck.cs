using System.Collections.Generic;

namespace battle_of_cards_cardgame {
    public class Deck {
        public ICardDAO CardDAO;
        List<Card> deck;
        public Deck (ICardDAO dao) {
            CardDAO = dao;
            GetAllCards ();
        }
        public void GetAllCards () {
            deck=CardDAO.CreateCards ();
            
        }
        public List<Queue<Card>> dealCards (int numberOfPlayers) {
            List<Queue<Card>> pilesOfCards = getPilesOfCards (numberOfPlayers); // funkcja odpowiedzialna za zrobienie tylu zestawów kart" ilu jest graczy.
            for (int i = 0, j = 0; i < deck.Count; i++, j++) { // iterator j odpowiada stworzenie tylu zestawu kart ile graczy:P.
                if (j == numberOfPlayers) {
                    j = 0;
                }
                pilesOfCards[j].Enqueue (deck[i]); // ta metoda Enqueue służy dodawaniu elementu do naszego zestatwu)
            }
            return pilesOfCards;
        }

        private List<Queue<Card>> getPilesOfCards (int numberOfPlayers) {
            List<Queue<Card>> pilesOfCards = new List<Queue<Card>> ();
            for (int i = 0; i < numberOfPlayers; i++) {
                pilesOfCards.Add (new Queue<Card> ());
            }
            return pilesOfCards;
        }
    }
}