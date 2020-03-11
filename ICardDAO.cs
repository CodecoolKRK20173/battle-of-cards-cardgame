using System.Collections.Generic;
namespace battle_of_cards_cardgame {
    public interface ICardDAO {
        List<Card> CreateCards ();
        Card GetCarByName ();
        void Update (Card car);
        void Delete (Card car);
    }
}