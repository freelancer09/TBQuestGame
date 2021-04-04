using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using TBQuestGame.PresentationLayer;
using System.Collections.ObjectModel;

namespace TBQuestGame.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player();
        Map _gameMap;
        Location _initialLocation;
        List<string> _messages;
        List<string> _dialogue;
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        private void InitializeDataSet()
        {
            _messages = GameData.InitialMessages();
            _gameMap = GameData.GameMap();
            _dialogue = GameData.DefaultDialogue();
            _initialLocation = _gameMap.Locations.FirstOrDefault(l => l.Id == GameData.InitialGameMapLocation());

        }
        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _gameMap,
                _initialLocation,
                _messages,
                _dialogue
                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            _playerSetupView.Close();
        }
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                _player.Money = 20;
                _player.Stamina = 100;
                _player.MaxStamina = 100;
                _player.Inventory = GameData.InitialGameItems();

            }
            else _player = GameData.PlayerData();
        }
    }
}
