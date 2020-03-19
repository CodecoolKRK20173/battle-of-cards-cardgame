using System.Collections.Generic;
using System;

namespace battle_of_cards_cardgame 
{
    public class Table
    {
        public List<Card> activCards{get;set;}
        private List<Card> cardsAfterDraw;
        private Dictionary<Card, Player> whoCards; 
        public IComparer<Card> comparator{get;set;}

        public Table()
        {
            // this.comparator = comparator;
            activCards = new List<Card>();
            cardsAfterDraw = new List<Card>();
            whoCards = new Dictionary<Card, Player>();
            

        }

        public int PutCard(Card card, Player player)
        {
            whoCards.Add(card, player);
            activCards.Add(card);
            return activCards.Count;
        }

        private bool AllCardsEqual()
        {   
            try
            {
                for(int i=0; i < activCards.Count - 1; i++)
                {
                    for(int j=i+1; j < activCards.Count; j++)
                    {
                        if(comparator.Compare(activCards[i], activCards[j]) != 0)
                            return false;
                    }
                        
                }
                return true;
            } 
            catch(IndexOutOfRangeException exc)
            {
                return false;
            }
        }

        private Card GetWinningCard()
        {  
            if (AllCardsEqual())
                return null;
            
            Card winningCard = activCards[0];
    
            foreach(Card card in activCards)
            {
                if(comparator.Compare(card, winningCard) > 0)
                {
                    winningCard = card;
                }

            }
            return winningCard;
        }

        //return all cards from activCards and last round cards- cardsAfterDraw
        public List<Card> GetRoundTrophy()
        {   
            List<Card> trophy = new List<Card>();
            Card winningCard = GetWinningCard();
            
            if(winningCard != null)
            {
                foreach(Card ele in activCards)
                {
                    trophy.Add(ele);
                }
                foreach(Card ele in cardsAfterDraw)
                {
                    trophy.Add(ele);
                }
            } 
            return trophy;  

        }

        public Player GetRoundWinner()
        {

            try
            {
                return whoCards[GetWinningCard()];
            }
            catch(KeyNotFoundException exc)
            {
                return null;
            }
            catch(ArgumentNullException exc)
            {
                return null;
            }
        }

        public void MoveActivCardsToAfterDraw()
        {
            foreach(Card ele in activCards)
            {
                cardsAfterDraw.Add(ele);
            }
            activCards.Clear();
        }

        

    }

}