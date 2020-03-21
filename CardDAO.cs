using System;
using System.Collections.Generic;
using System.IO;

namespace battle_of_cards_cardgame {
    public class CardDAO : ICardDAO {
        private string _path;
        public CardDAO (string sourcePath) 
        {
            _path = sourcePath;
        }

        public List<Card> CreateCards () 
        {
            var TxtFileContent = LoadFromFile ();
            var Cards = new List<Card> ();

            for (int i = 0; i < TxtFileContent.Length; i++) 
            {
                var singleCarEntry = TxtFileContent[i].Split (",");

                try
                {
                    var Card = ParseCarsBaseOn (singleCarEntry);
                    Cards.Add (Card);    
                }
                catch (FormatException)
                {
                    View.DisplayMessage("Unable to convert card from file.");
                }
                catch (OverflowException)
                {
                    View.DisplayMessage("Values are out of range of the int type.");
                }
        
            }
            return Cards;
        }

        private string[] LoadFromFile () 
        {
            return System.IO.File.ReadAllLines (_path);
        }

        private Card ParseCarsBaseOn (params string[] data) 
        {
            return new Card (data[0], Int32.Parse (data[1]), Int32.Parse (data[2]), Int32.Parse (data[3]), data[4]);
        }
        public void Delete (Card car) 
        {
            throw new System.NotImplementedException ();
        }

        public Card GetCarByName () 
        {
            throw new System.NotImplementedException ();
        }

        public void Update (Card Car) 
        {
            throw new System.NotImplementedException ();
        }

    }
}