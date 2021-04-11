using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Player : Character, ITrade
    {
        #region ENUMS

        #endregion

        #region FIELDS
        protected ObservableCollection<GameItem> _inventory;
        private int _skillMath;
        private int _skillScience;
        private int _skillEnglish;
        private int _skillHistory;
        private int _skillPhysical;
        private int _stamina;
        private int _maxStamina;
        private double _money;

        #endregion

        #region PROPERTIES
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
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

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _inventory = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        public bool LearnSkill(string skill, int increase)
        {
            if (skill == "Math")
            {
                SkillMath += increase;
                return true;
            }
            else if (skill == "Science")
            {
                SkillScience += increase;
                return true;
            }
            else if (skill == "History")
            {
                SkillHistory += increase;
                return true;
            }
            else if (skill == "English")
            {
                SkillEnglish += increase;
                return true;
            }
            else if (skill == "Physical")
            {
                SkillPhysical += increase;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) Inventory.Add(selectedGameItem);
        }
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) Inventory.Remove(selectedGameItem);
        }

        #endregion
    }
}
