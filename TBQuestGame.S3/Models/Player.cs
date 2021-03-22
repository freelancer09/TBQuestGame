using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private int _skillMath;
        private int _skillScience;
        private int _skillEnglish;
        private int _skillHistory;
        private int _skillPhysical;
        private int _stamina;
        private int _maxStamina;
        private double _money;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _books;
        private ObservableCollection<GameItem> _foods;

        #endregion

        #region PROPERTIES

        public int SkillMath
        {
            get { return _skillMath; }
            set { 
                _skillMath = value;
                OnPropertyChanged(nameof(SkillMath));
            }
        }
        public int SkillScience
        {
            get { return _skillScience; }
            set { 
                _skillScience = value;
                OnPropertyChanged(nameof(SkillScience));
            }
        }
        public int SkillEnglish
        {
            get { return _skillEnglish; }
            set { 
                _skillEnglish = value;
                OnPropertyChanged(nameof(SkillEnglish));
            }
        }
        public int SkillHistory
        {
            get { return _skillHistory; }
            set { 
                _skillHistory = value;
                OnPropertyChanged(nameof(SkillHistory));
            }
        }
        public int SkillPhysical
        {
            get { return _skillPhysical; }
            set { 
                _skillPhysical = value;
                OnPropertyChanged(nameof(SkillPhysical));
            }
        }
        public int Stamina
        {
            get { return _stamina; }
            set { 
                _stamina = value;
                OnPropertyChanged(nameof(Stamina));
            }
        }
        public int MaxStamina
        {
            get { return _maxStamina; }
            set { _maxStamina = value; }
        }
        public double Money
        {
            get { return _money; }
            set {
                _money = value;
                OnPropertyChanged(nameof(Money));
            }
        }
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItem> Books
        {
            get { return _books; }
            set { _books = value; }
        }
        public ObservableCollection<GameItem> Foods
        {
            get { return _foods; }
            set { _foods = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _inventory = new ObservableCollection<GameItem>();
            _books = new ObservableCollection<GameItem>();
            _foods = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        public override string DefaultGreeting()
        {
            return $"You know who you are, {_name}";
        }
        public override int Location()
        {
            return _locationId;
        }
        public void UpdateInventoryCategories()
        {
            Books.Clear();
            Foods.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Book) Books.Add(gameItem);
                if (gameItem is Food) Foods.Add(gameItem);
            }
        }
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) _inventory.Add(selectedGameItem);
        }
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) _inventory.Remove(selectedGameItem);
        }
        #endregion
    }
}
