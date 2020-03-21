using System.Collections.Generic;
using System;

namespace battle_of_cards_cardgame 
{
    public class Table
    {
        public List<Card> ActiveCards{get;set;}
        public List<Card> CardsAfterDraw{get;set;}
        public Dictionary<Card, Player> WhoseCards{get;set;} 
        public IComparer<Card> Comparator{get;set;}

        public Player WinningPlayer{ get; set; }

        public Table()
        {
            
            ActiveCards = new List<Card>();
            CardsAfterDraw = new List<Card>();
            WhoseCards = new Dictionary<Card, Player>();

        }

        public int PutCard(Card card, Player player)
        {
            WhoseCards.Add(card, player);
            ActiveCards.Add(card);
            return ActiveCards.Count;
        }

        private bool AllCardsEqual()
        {   
            try
            {
                for(int i=0; i < ActiveCards.Count - 1; i++)
                {
                    for(int j=i+1; j < ActiveCards.Count; j++)
                    {
                        if(Comparator.Compare(ActiveCards[i], ActiveCards[j]) != 0)
                            return false;
                    }
                        
                }
                return true;
            } 
            catch(IndexOutOfRangeException)
            {
                View.DisplayMessage("Index out of range!");
                View.WaitForEnter();
                return false;
            }
        }

        private Card GetWinningCard()
        {  
            if (AllCardsEqual())
                return null;

            Card winningCard;
            int comparationResult=Comparator.Compare(ActiveCards[0], ActiveCards[1]);
            if(comparationResult==1)
            {
                winningCard = ActiveCards[0];
            }
            else
            {
                winningCard = ActiveCards[1];
            }
            
            // Card winningCard = activCards[0];
            // foreach(Card card in activCards)
            // {
            //     if(comparator.Compare(card, winningCard) > 0)
            //     {
            //         winningCard = card;
            //     }

            // }
            return winningCard;
        }

        //return all cards from activCards and last round cards- cardsAfterDraw
        public List<Card> GetRoundTrophy()
        {   
            List<Card> trophy = new List<Card>();
            Card winningCard = GetWinningCard();
            
            if(winningCard != null)
            {
                foreach(Card ele in ActiveCards)
                {
                    trophy.Add(ele);
                }
                foreach(Card ele in CardsAfterDraw)
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
                WinningPlayer = WhoseCards[GetWinningCard()];
                return WinningPlayer;
            }
            catch(KeyNotFoundException)
            {
                View.DisplayMessage("No winner!");
                View.WaitForEnter();
                return null;
            }
            catch(ArgumentNullException)
            {
                View.DisplayMessage("No winning card!");
                return null;
            }
        }

        public void MoveActivCardsToAfterDraw()
        {
            foreach(Card ele in ActiveCards)
            {
                CardsAfterDraw.Add(ele);
            }
            ActiveCards.Clear();
        }

        

    }

}
