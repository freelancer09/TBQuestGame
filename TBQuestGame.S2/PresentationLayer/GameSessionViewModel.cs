using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private Player _player;
        private List<string> _messages;
        private Map _gameMap;
        private Location _currentLocation, _northLocation, _eastLocation, _southLocation, _westLocation;

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }
        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { 
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }
        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }
        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }
        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }
        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }
        public bool HasNorthLocation { get { return NorthLocation != null; } }
        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }
        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, Map gameMap, Location currentLocation, List<string> initialMessages)
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocation = currentLocation;
            _currentLocation = currentLocation;
            _messages = initialMessages;

            InitializeView();
        }

        #endregion

        #region METHODS

        private void InitializeView()
        {
            UpdateAvailableTravelPoints();
        }

        private void UpdateAvailableTravelPoints()
        {
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();

                if (nextNorthLocation.Accessible == true)
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();

                if (nextEastLocation.Accessible == true)
                {
                    EastLocation = nextEastLocation;
                }
            }

            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();

                if (nextSouthLocation.Accessible == true)
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();

                if (nextWestLocation.Accessible == true)
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.Move(_gameMap.NorthLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                _messages.Insert(0, "You moved to " + _gameMap.CurrentLocation.Name + ".");
                OnPropertyChanged(nameof(MessageDisplay));
                UpdateAvailableTravelPoints();
            }
        }
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.Move(_gameMap.EastLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                _messages.Insert(0, "You moved to " + _gameMap.CurrentLocation.Name + ".");
                OnPropertyChanged(nameof(MessageDisplay));
                UpdateAvailableTravelPoints();
            }
        }
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.Move(_gameMap.SouthLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                _messages.Insert(0, "You moved to " + _gameMap.CurrentLocation.Name + ".");
                OnPropertyChanged(nameof(MessageDisplay));
                UpdateAvailableTravelPoints();
            }
        }
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.Move(_gameMap.WestLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                _messages.Insert(0, "You moved to " + _gameMap.CurrentLocation.Name + ".");
                OnPropertyChanged(nameof(MessageDisplay));
                UpdateAvailableTravelPoints();
            }
        }

        #endregion
    }
}
