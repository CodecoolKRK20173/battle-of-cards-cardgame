using System.Collections.Generic;
using System.IO;

namespace battle_of_cards_cardgame {
    public class CardDAO : ICardDAO {
        public List<Card> Cards { get; set; }
        public string Path { get; set; }
        public CardDAO (string sourcePath) {
            Path = sourcePath;
        }

        public List<Card> CreateCards () {
            var TxtFileContent = LoadFromFile ();
            var Cards = new List<Card> ();

            for (int i = 0; i < TxtFileContent.Length; i++) {
                var singleCarEntry = TxtFileContent[i].Split (",");
                var Card = ParseCarsBaseOn (singleCarEntry);
                Cards.Add (Card);
            }
            return Cards;
        }

        private string[] LoadFromFile () {
            return System.IO.File.ReadAllLines (Path);
        }

        private Card ParseCarsBaseOn (params string[] data) {
            return new Card (data[0], int.Parse (data[1]), int.Parse (data[2]), int.Parse (data[3]), data[4]);
        }
        public void Delete (Card car) {
            throw new System.NotImplementedException ();
        }

        public Card GetCarByName () {
            throw new System.NotImplementedException ();
        }

        public void Update (Card Car) {
            throw new System.NotImplementedException ();
        }
        public void DoSth () {

        }
    }
}