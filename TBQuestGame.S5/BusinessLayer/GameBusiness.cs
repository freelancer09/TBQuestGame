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
        ObservableCollection<Mission> _missions;
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
            _missions = GameData.InitialMissions();
            _initialLocation = _gameMap.Locations.FirstOrDefault(l => l.Id == GameData.InitialGameMapLocation());
        }
        private void InstantiateAndShowView()
        {
            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                _gameMap,
                _initialLocation,
                _messages,
                _dialogue,
                _missions
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
                string tempName = _player.Name;
                _player = GameData.PlayerData();
                _player.Name = tempName;
            }
            else _player = GameData.PlayerData();
        }



    }
}
