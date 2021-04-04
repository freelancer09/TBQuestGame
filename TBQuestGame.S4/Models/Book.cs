using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Book : GameItem
    {

        #region ENUMS

        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES

        public string StatModify { get; set; }
        public int StatChange { get; set; }
        public bool Used { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Book()
        {

        }

        public Book(int id, string name, string description, int value, string statModify, int statChange, bool used) :
            base(id, name, description, value)
        {
            StatModify = statModify;
            StatChange = statChange;
            Used = used;
        }

        #endregion

        #region METHODS


        #endregion
    }
}
