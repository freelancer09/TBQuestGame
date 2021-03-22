using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Food : GameItem
    {

        #region ENUMS

        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES

        public string StatModify { get; set; }
        public int StatChange { get; set; }
        public int Uses { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Food()
        {

        }

        public Food(int id, string name, string description, int value, string statModify, int statChange, int uses )
            : base(id, name, description, value)
        {
            StatModify = statModify;
            StatChange = statChange;
            Uses = uses;
        }

        #endregion

        #region METHODS

        public override string InformationString()
        {
            return $"{Name}: {Description}\n{StatModify}: {StatChange} ({Uses})";
        }

        #endregion
    }
}
