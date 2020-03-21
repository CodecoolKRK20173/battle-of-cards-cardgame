using System;
using System.Collections.Generic;

namespace battle_of_cards_cardgame
{
    public class Deck
    {
        private ICardDAO cardDAO;
        List<Card> deck;
        public Deck(ICardDAO dao)
        {
            cardDAO = dao;
            GetAllCards();
            Shuffle();
        }
        private void GetAllCards()
        {
            deck = cardDAO.CreateCards();
        }
        public List<Queue<Card>> DealCards(int numberOfPlayers)
        {
            List<Queue<Card>> pilesOfCards = GetPilesOfCards(numberOfPlayers);
            for (int i = 0, j = 0; i < deck.Count; i++, j++)
            {
                if (j == numberOfPlayers)
                {
                    j = 0;
                }
                pilesOfCards[j].Enqueue(deck[i]);
            }
            return pilesOfCards;
        }

        private List<Queue<Card>> GetPilesOfCards(int numberOfPlayers)
        {
            List<Queue<Card>> pilesOfCards = new List<Queue<Card>>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                pilesOfCards.Add(new Queue<Card>());
            }
            return pilesOfCards;
        }
        private void Shuffle()
        {
            Random random = new Random();
            List<Card> temp = new List<Card>();
            for (int i = 0; i < deck.Count; i++)
            {
                int randomIndex = random.Next(deck.Count);
                while (temp.Contains(deck[randomIndex]) == true)
                {
                    randomIndex = random.Next(deck.Count);
                }
                temp.Add(deck[randomIndex]);
            }
            deck = temp;
        }

    }
}