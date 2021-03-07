using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        #region ENUMS

        #endregion

        #region FIELDS

        protected int _skillMath;
        protected int _skillScience;
        protected int _skillEnglish;
        protected int _skillHistory;
        protected int _skillPhysical;
        protected int _stamina;
        protected double _money;

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
        #endregion
    }
}
