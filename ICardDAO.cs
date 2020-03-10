using System.Collections.Generic;
namespace battle_of_cards_cardgame {
    public interface ICardDAO {
        List<Card> GetCards ();
        Card GetCarByName ();
        void Update (Card footballer);
        void Delete (Card footballer);
    }
}