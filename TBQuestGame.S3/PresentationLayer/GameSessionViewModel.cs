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

        private GameItem _currentGameItem;

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
        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
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
            _player.UpdateInventoryCategories();
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
        public void NewMessage(string message)
        {
            _messages.Insert(0, message);
            OnPropertyChanged(nameof(MessageDisplay));
        }
        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.Move(_gameMap.NorthLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                NewMessage("You moved to " + _gameMap.CurrentLocation.Name + ".");                
                UpdateAvailableTravelPoints();
                UpdateMoveStamina();
            }
        }
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.Move(_gameMap.EastLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                NewMessage("You moved to " + _gameMap.CurrentLocation.Name + ".");
                UpdateAvailableTravelPoints();
                UpdateMoveStamina();
            }
        }
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.Move(_gameMap.SouthLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                NewMessage("You moved to " + _gameMap.CurrentLocation.Name + ".");
                UpdateAvailableTravelPoints();
                UpdateMoveStamina();
            }
        }
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.Move(_gameMap.WestLocation());
                CurrentLocation = _gameMap.CurrentLocation;
                NewMessage("You moved to " + _gameMap.CurrentLocation.Name + ".");
                UpdateAvailableTravelPoints();
                UpdateMoveStamina();
            }
        }
        public void UpdateMoveStamina()
        {
            if (_player.Stamina > 0) _player.Stamina--;
        }
        public void AddItemToInventory()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                NewMessage("You picked up " + selectedGameItem.Name + ".");               
            }
        }
        public void RemoveItemFromInventory()
        {
            if (_currentGameItem != null)
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                NewMessage("You dropped " + selectedGameItem.Name + ".");
            }
        }
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Book book:
                    ProcessBookUse(book);
                    break;
                case Food food:
                    ProcessFoodUse(food);
                    break;
                default:
                    break;
            }
        }   
        private void ProcessBookUse(Book book)
        {
            string message = "";

            if (book.Used == false)
            {
                if (book.StatModify == "Math")
                {
                    _player.SkillMath += book.StatChange;
                    book.Used = true;
                    book.Name += " (Read)";
                    message = "Your math skill increased by " + book.StatChange + "!"; 
                }
                else if (book.StatModify == "Science")
                {
                    _player.SkillScience += book.StatChange;
                    book.Used = true;
                    book.Name += " (Read)";
                    message = "Your science skill increased by " + book.StatChange + "!";
                }
                else if (book.StatModify == "History")
                {
                    _player.SkillHistory += book.StatChange;
                    book.Used = true;
                    book.Name += " (Read)";
                    message = "Your history skill increased by " + book.StatChange + "!";
                }
                else if (book.StatModify == "English")
                {
                    _player.SkillEnglish += book.StatChange;
                    book.Used = true;
                    book.Name += " (Read)";
                    message = "Your english skill increased by " + book.StatChange + "!";
                }
                else if (book.StatModify == "Physical")
                {
                    _player.SkillPhysical += book.StatChange;
                    book.Used = true;
                    book.Name += " (Read)";
                    message = "Your physical skill increased by " + book.StatChange + "!";
                }
                _player.RemoveGameItemFromInventory(book);
                _player.AddGameItemToInventory(book);
            }
            if (message != "") NewMessage(message);
        }
        private void ProcessFoodUse(Food food)
        {
            string message = "";

            if (food.Uses > 0)
            {
                if (food.StatModify == "Stamina")
                {
                    if (_player.Stamina < _player.MaxStamina)
                    { 
                        _player.Stamina += food.StatChange;
                        if (_player.Stamina > _player.MaxStamina) _player.Stamina = _player.MaxStamina;
                        food.Uses--;
                        if (food.Uses == 0) _player.RemoveGameItemFromInventory(_currentGameItem);
                        else
                        {
                            _player.RemoveGameItemFromInventory(food);
                            _player.AddGameItemToInventory(food);
                        }
                        message = "Your stamina recovered by " + food.StatChange + ".";
                    }
                    else
                    {
                        message = "Your stamina is already full.";
                    }
                }
            }

            if (message != "") NewMessage(message);
        }
        public void OnExamineGameItem()
        {
            switch (_currentGameItem)
            {
                case Book book:
                    ProcessBookExamine(book);
                    break;
                case Food food:
                    ProcessFoodExamine(food);
                    break;
                default:
                    break;
            }
        }
        private void ProcessBookExamine(Book book)
        {
            GameItemExamineView gameItemExamineView = new GameItemExamineView();
            gameItemExamineView.NameLabel.Content = book.Name;
            gameItemExamineView.InformationTextBlock.Text = book.Description + "\n\nImproves " + book.StatModify + " by " + book.StatChange + "\nValue: " + book.Value;
            gameItemExamineView.ShowDialog();
        }
        private void ProcessFoodExamine(Food food)
        {
            GameItemExamineView gameItemExamineView = new GameItemExamineView();
            gameItemExamineView.NameLabel.Content = food.Name;
            gameItemExamineView.InformationTextBlock.Text = food.Description + "\n\nRestores " + food.StatChange + " " + food.StatModify + "\nRemaining Uses: " + food.Uses + "\nValue: " + food.Value;
            gameItemExamineView.ShowDialog();
        }
        #endregion
    }
}
