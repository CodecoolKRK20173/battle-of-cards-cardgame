using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace battle_of_cards_cardgame 
{
    public class CardDAO : ICardDAO 
    {
        private string _path;
        public CardDAO (string sourcePath) 
        {
            _path = sourcePath;
        }

        public List<Card> CreateCardsFromFile() 
        {
            var cards = new List<Card> ();
            switch(Path.GetExtension(_path))
            {
                case (".csv"):
                    cards = CreateCardsFromTxt();
                    break;
                case (".xml"):
                    cards = CreateCardsFromXml();
                    break;
                default:
                    throw new InvalidDataException("Invalid source file extension");
            }
            return cards;
        }

        private List<Card> CreateCardsFromTxt()  
        {
            var cardsFromTxt = new List<Card>();
            var txtFileContent = LoadFromFileTxt ();
            for (int i = 0; i < txtFileContent.Length; i++) 
            {
                var singleCardEntry = txtFileContent[i].Split (",");
                cardsFromTxt.Add (CreateSingleCard (singleCardEntry));    
            }
            return cardsFromTxt;
        }

        private List<Card> CreateCardsFromXml()
        {
            var cardsFromXml = new List<Card>();
            var xmlDocument = LoadFromFileXML();
            List<string> singleCardEntry;

            foreach(XmlNode element in xmlDocument.DocumentElement)
            {   
                singleCardEntry = new List<string>();
                foreach(XmlNode attribute in element.ChildNodes)
                {
                    singleCardEntry.Add(attribute.InnerText);
                }

                cardsFromXml.Add (CreateSingleCard (singleCardEntry.ToArray()));
            }
            return cardsFromXml;
        }

        public Card CreateSingleCard(params string[] singleCarEntry)
        {
            try
            {
                var card = ParseCarsBaseOn (singleCarEntry);
                return card;    
            }
            catch (FormatException)
            {
                View.DisplayMessage("Unable to convert card from file.");
            }
            catch (OverflowException)
            {
                View.DisplayMessage("Values are out of range of the int type.");
            }
            return null;
        }

        public XmlDocument LoadFromFileXML()
        {
            int nameIndex = 0;
            var doc = new XmlDocument();
            doc.Load(_path);
            return doc;
        }

        private string[] LoadFromFileTxt () 
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