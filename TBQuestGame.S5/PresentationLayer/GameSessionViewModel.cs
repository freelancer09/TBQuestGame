using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;
using System.Windows.Media;
using TBQuestGame.BusinessLayer;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private Random random = new Random();
        private Player _player;
        private List<string> _messages;
        private List<string> _defaultDialogue;
        private Map _gameMap;
        private Location _currentLocation, _northLocation, _eastLocation, _southLocation, _westLocation;

        private GameItem _currentGameItem, _currentTradeViewNpcGameItem, _currentTradeViewPlayerGameItem;
        private Npc _currentNpc;
        private NpcTradeView _npcTradeView;
        private ObservableCollection<GameItem> _tradeViewNpcInventory, _tradeViewPlayerInventory;
        private double _tradeViewCurrentMoney, _tradeViewPendingMoney, _tradeViewFinalMoney;
        private string _tradeViewErrorMessage;

        private ObservableCollection<Mission> _missions;

        private static PlayerBusiness _gBusiness = new PlayerBusiness();

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set 
            { 
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }
        public List<string> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(MessageDisplay));
            }
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
        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set 
            { 
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }
        public ObservableCollection<GameItem> TradeViewNpcInventory
        {
            get { return _tradeViewNpcInventory; }
            set { _tradeViewNpcInventory = value; }
        }
        public ObservableCollection<GameItem> TradeViewPlayerInventory
        {
            get { return _tradeViewPlayerInventory; }
            set { _tradeViewPlayerInventory = value; }
        }
        public bool HasNorthLocation { get { return NorthLocation != null; } }
        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }
        public GameItem CurrentTradeViewNpcGameItem
        {
            get { return _currentTradeViewNpcGameItem; }
            set { _currentTradeViewNpcGameItem = value; }
        }
        public GameItem CurrentTradeViewPlayerGameItem
        {
            get { return _currentTradeViewPlayerGameItem; }
            set { _currentTradeViewPlayerGameItem = value; }
        }
        public double TradeViewCurrentMoney
        {
            get { return _tradeViewCurrentMoney; }
            set
            {
                _tradeViewCurrentMoney = value;
                OnPropertyChanged(nameof(TradeViewCurrentMoney));
            }
        }
        public double TradeViewPendingMoney
        {
            get { return _tradeViewPendingMoney; }
            set
            {
                _tradeViewPendingMoney = value;
                OnPropertyChanged(nameof(TradeViewPendingMoney));
            }
        }
        public double TradeViewFinalMoney
        {
            get { return _tradeViewFinalMoney; }
            set
            {
                _tradeViewFinalMoney = value;
                OnPropertyChanged(nameof(TradeViewFinalMoney));
            }
        }
        public string TradeViewErrorMessage
        {
            get { return _tradeViewErrorMessage; }
            set
            {
                _tradeViewErrorMessage = value;
                OnPropertyChanged(nameof(TradeViewErrorMessage));
            }
        }
        public List<string> DefaultDialogue
        {
            get { return _defaultDialogue; }
            set { _defaultDialogue = value; }
        }
        public ObservableCollection<Mission> Missions
        {
            get { return _missions; }
            set 
            { 
                _missions = value;
                OnPropertyChanged(nameof(Missions));
            }
        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, Map gameMap, Location currentLocation, List<string> initialMessages, List<string> dialogue, ObservableCollection<Mission> missions)
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocation = currentLocation;
            _currentLocation = currentLocation;
            _messages = initialMessages;
            _defaultDialogue = dialogue;
            _tradeViewNpcInventory = new ObservableCollection<GameItem>();
            _tradeViewPlayerInventory = new ObservableCollection<GameItem>();
            _tradeViewErrorMessage = "";
            _missions = missions;            

            InitializeView();
        }

        #endregion

        #region METHODS

        private void InitializeView()
        {
            UpdateAvailableTravelPoints();
        }
        public void NewMessage(string message)
        {
            Messages.Insert(0, message);
            OnPropertyChanged(nameof(MessageDisplay));
        }

        public void MoveNorth()
        {
            if (Player.Stamina > 0)
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
            else
            {
                NewMessage("You're too tired to move.");
            }

        }
        public void MoveEast()
        {
            if (Player.Stamina > 0)
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
            else 
            {
                NewMessage("You're too tired to move.");
            }
        }
        public void MoveSouth()
        {
            if (Player.Stamina > 0)
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
            else
            {
                NewMessage("You're too tired to move.");
            }
        }
        public void MoveWest()
        {
            if (Player.Stamina > 0)
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
            else
            {
                NewMessage("You're too tired to move.");
            }
        }
        private void UpdateMoveStamina()
        {
            if (Player.Stamina > 0) Player.Stamina--;
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

        public void PickUpItem()
        {
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                Player.AddGameItemToInventory(selectedGameItem);

                NewMessage("You picked up " + selectedGameItem.Name + ".");               
            }
        }
        public void PutDownItem()
        {
            if (_currentGameItem != null)
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                Player.RemoveGameItemFromInventory(selectedGameItem);

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
                if (Player.LearnSkill(book.StatModify, book.StatChange))
                {
                    book.Used = true;
                    book.Name += " (Read)";
                    book.Value /= 2;
                    message = "Your " + book.StatModify + " skill increased by " + book.StatChange + "!";
                }
                Player.RemoveGameItemFromInventory(book);
                Player.AddGameItemToInventory(book);
            }
            if (message != "") NewMessage(message);
            MissionUpdate();
        }
        private void ProcessFoodUse(Food food)
        {
            string message = "";

            if (food.Uses > 0)
            {
                if (food.StatModify == "Stamina")
                {
                    if (Player.Stamina < Player.MaxStamina)
                    { 
                        Player.Stamina += food.StatChange;
                        if (Player.Stamina > Player.MaxStamina) Player.Stamina = Player.MaxStamina;
                        food.Uses--;
                        if (food.Uses == 0) Player.RemoveGameItemFromInventory(_currentGameItem);
                        else
                        {
                            Player.RemoveGameItemFromInventory(food);
                            Player.AddGameItemToInventory(food);
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
            MissionUpdate();
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

        public void OnNpcTrade(GameSessionViewModel gameSessionViewModel)
        {
            _npcTradeView = new NpcTradeView(gameSessionViewModel);
            TradeViewCurrentMoney = Player.Money;
            TradeViewPendingMoney = 0;
            TradeViewFinalMoney = Player.Money;
            TradeViewNpcInventory.Clear();
            TradeViewPlayerInventory.Clear();
            foreach(GameItem gameItem in CurrentNpc.Inventory)
            {
                TradeViewNpcInventory.Add(gameItem);
            }
            foreach(GameItem gameItem in Player.Inventory)
            {
                TradeViewPlayerInventory.Add(gameItem);
            }
            
            _npcTradeView.ShowDialog();
        }
        public void BuyItem()
        {
            if (_npcTradeView.NpcItemsDataGrid.SelectedItem != null)
            {
                TradeViewPendingMoney -= CurrentTradeViewNpcGameItem.Value;
                TradeViewFinalMoney = TradeViewCurrentMoney + TradeViewPendingMoney;
                if (TradeViewPendingMoney < 0) _npcTradeView.PendingMoneyLabel.Foreground = Brushes.Red;
                else _npcTradeView.PendingMoneyLabel.Foreground = Brushes.Green;
                if (TradeViewFinalMoney < 0) _npcTradeView.FinalMoneyLabel.Foreground = Brushes.Red;
                else _npcTradeView.FinalMoneyLabel.Foreground = Brushes.Black;
                TradeViewPlayerInventory.Add(CurrentTradeViewNpcGameItem);
                TradeViewNpcInventory.Remove(CurrentTradeViewNpcGameItem);
                TradeViewErrorMessage = "";
            }
        }
        public void SellItem()
        {
            if (_npcTradeView.PlayerItemsDataGrid.SelectedItem != null)
            {
                TradeViewPendingMoney += CurrentTradeViewPlayerGameItem.Value;
                TradeViewFinalMoney = TradeViewCurrentMoney + TradeViewPendingMoney;
                if (TradeViewPendingMoney < 0) _npcTradeView.PendingMoneyLabel.Foreground = Brushes.Red;
                else _npcTradeView.PendingMoneyLabel.Foreground = Brushes.Green;
                if (TradeViewFinalMoney < 0) _npcTradeView.FinalMoneyLabel.Foreground = Brushes.Red;
                else _npcTradeView.FinalMoneyLabel.Foreground = Brushes.Black;
                TradeViewNpcInventory.Add(CurrentTradeViewPlayerGameItem);
                TradeViewPlayerInventory.Remove(CurrentTradeViewPlayerGameItem);
                TradeViewErrorMessage = "";
            }
        }
        public void FinalizeTrade()
        {
            if (TradeViewFinalMoney < 0)
            {
                TradeViewErrorMessage = "Not enough money!";
            }
            else
            {
                Player.Money = TradeViewFinalMoney;
                Player.Inventory.Clear();
                CurrentNpc.Inventory.Clear();
                foreach(GameItem gameItem in TradeViewNpcInventory)
                {
                    CurrentNpc.Inventory.Add(gameItem);
                }
                foreach(GameItem gameItem in TradeViewPlayerInventory)
                {
                    Player.Inventory.Add(gameItem);
                }
                _npcTradeView.Close();
            }
        }
        public void OnExamineTradePlayerGameItem()
        {
            switch (_currentTradeViewPlayerGameItem)
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
        public void OnExamineTradeNpcGameItem()
        {
            switch (_currentTradeViewNpcGameItem)
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

        public void OnNpcTalk()
        {
            string message = "";

            if (CurrentNpc.Job == Character.JobTitle.Teacher)
            {
                message = CurrentNpc.NextDialogue();
                if (message != "")
                {
                    Player.LearnSkill(CurrentNpc.Skill, 1);
                    MissionUpdate();
                }
            }
            else
            {
                message = CurrentNpc.RandomDialogue();
            }
            if (message == "")
            { 
                message = DefaultDialogue[DieRoll(DefaultDialogue.Count()) - 1];
            }

            message = CurrentNpc.Name + ": \"" + message + "\"";
            NewMessage(message);
        }
        public void MissionUpdate()
        {
            List<Mission> tempMissions = new List<Mission>();
            foreach(Mission mission in Missions)
            {
                if (mission.Done == false)
                {
                    if (mission.SkillNeeded == "Math" && Player.SkillMath >= Mission.SKILL_NEEDED)
                    {
                        mission.Done = true;
                        Player.AddGameItemToInventory(mission.Reward);
                        NewMessage("Objective complete!");
                        NewMessage("You received a " + mission.Reward.Name + ".");
                    }
                    else if (mission.SkillNeeded == "Science" && Player.SkillScience >= Mission.SKILL_NEEDED)
                    {
                        mission.Done = true;
                        Player.AddGameItemToInventory(mission.Reward);
                        NewMessage("Objective complete!");
                        NewMessage("You received a " + mission.Reward.Name + ".");
                    }
                    else if (mission.SkillNeeded == "History" && Player.SkillHistory >= Mission.SKILL_NEEDED)
                    {
                        mission.Done = true;
                        Player.AddGameItemToInventory(mission.Reward);
                        NewMessage("Objective complete!");
                        NewMessage("You received a " + mission.Reward.Name + ".");
                    }
                    else if (mission.SkillNeeded == "English" && Player.SkillEnglish >= Mission.SKILL_NEEDED)
                    {
                        mission.Done = true;
                        Player.AddGameItemToInventory(mission.Reward);
                        NewMessage("Objective complete!");
                        NewMessage("You received a " + mission.Reward.Name + ".");
                    }
                    else if (mission.SkillNeeded == "Physical" && Player.SkillPhysical >= Mission.SKILL_NEEDED)
                    {
                        mission.Done = true;
                        Player.AddGameItemToInventory(mission.Reward);
                        NewMessage("Objective complete!");
                        NewMessage("You received a " + mission.Reward.Name + ".");
                    }
                }
                tempMissions.Add(mission);
            }
            Missions.Clear();
            foreach(Mission m in tempMissions)
            {
                Missions.Add(m);
            }
        }
        public int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
        public void SaveGame()
        {
            NewMessage("Game saved.");
            _gBusiness.SavePlayer(Player);
            _gBusiness.SaveMap(GameMap);
            _gBusiness.SaveLog(Messages);            
        }
        public void LoadGame()
        {
            Player loadPlayer = _gBusiness.GetPlayer();
            Map loadMap = _gBusiness.GetMap();
            List<string> loadLog = _gBusiness.GetLog();
            if (loadPlayer != null) Player = loadPlayer;
            if (loadMap != null) GameMap = loadMap;
            if (loadLog.Count() > 0) Messages = loadLog;

            MissionUpdate();
            UpdateAvailableTravelPoints();
            CurrentLocation = GameMap.CurrentLocation;
            NewMessage("Game loaded.");
        }

        #endregion
    }
}
