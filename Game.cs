using System;
using System.Collections.Generic;
// using Player;
// using Table;
// using GameView;


namespace battle_of_cards_cardgame
{

    public class Game
    {
        private List<Player> _players;
        private Player _activePlayer;
        private bool _isActive;
        private GameView _gameView;
        private Table _table;



        public Game(List<Player> players)
        {
            _players = players;
            _isActive = true;
            _gameView = new GameView();
            _table = new Table();
            Play();

        }

        private void Play()
        {

            _activePlayer = _players[0];
            while (_isActive)
            {
                HandleRound();
                ChangeActivePlayer();
            }


        }
        // private int GetChoiceFromActivePlayer()
        // {
        //     GameView.DisplayMessage("Select which attribiute You want to play:");
        //     return _activePlayer.GetChoice();
        // }

        void HandleRound()
        {

            _gameView.DisplayPlayer(_activePlayer);

            AssignTopCardsToPlayers();

            _gameView.DisplayCard(_table.ActiveCards[0],_activePlayer);

            int playerChoice = _activePlayer.GetChoice();
            CardAtributte attribute = (CardAtributte)playerChoice;

            //roundGame
            CardsComparer Comparator = new CardsComparer(attribute);
            _table.Comparator = Comparator;
            Player roundWinner = _table.GetRoundWinner();
            _gameView.DisplayTable(_table, attribute, _activePlayer);

            //substract top cards from hand player
            foreach (Player player in _players)
            {
                player.Cards.Dequeue();
            }

            //add cards to winner if is
            if (roundWinner != null)
            {
                foreach (Card elem in _table.GetRoundTrophy())
                {
                    roundWinner.Cards.Enqueue(elem);

                }
                _table.ActiveCards.Clear();
                _table.CardsAfterDraw.Clear();
            }
            //if nobody won round game them cards are adding to cardsAfterDraw
            else
            {
                _table.MoveActivCardsToAfterDraw();
            }

            //check that one player has all cards
            IsOver();
            if (_isActive == false)
            {
                _gameView.DisplayEndGame(GetWinnerGame());
            }
            _table.WhoseCards.Clear();

        }

        private void ChangeActivePlayer()
        {
            if (_activePlayer == _players[0])
            {
                _activePlayer = _players[1];
            }
            else
            {
                _activePlayer = _players[0];
            }
        }

        private void AssignTopCardsToPlayers()
        {
            foreach (Player player in _players)
            {
                _table.PutCard(player.Cards.Peek(), player);
            }

        }

        // Player getWinnerRound()
        // {
        //     //method which return card of winner player
        //     return _table.GetRoundWinner();
        // }

        Player GetWinnerGame()
        {
            Player winner = null;
            foreach (Player player in _players)
            {
                if (player.Cards.Count > 0)
                {
                    winner = player;
                }
            }
            return winner;
        }

        private bool IsOver()
        {
            int playersWithoutCards = 0;
            int numberOfPlayers = _players.Count;
            foreach (Player player in _players)
            {
                if (player.Cards.Count == 0)
                {
                    playersWithoutCards++;
                }
                if (playersWithoutCards == numberOfPlayers - 1)
                {
                    return _isActive = false;
                }
            }
            return _isActive = true;
        }

    }
}



