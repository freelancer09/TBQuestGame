using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public abstract class Character : ObservableObject
    {
        #region ENUMS

        public enum JobTitle
        {
            Student,
            Teacher,
            Faculty
        }

        #endregion

        #region FIELDS

        protected int _id;
        protected string _name;
        protected JobTitle _job;
        protected Random random = new Random();

        #endregion

        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public JobTitle Job
        {
            get { return _job; }
            set { _job = value;  }
        }

        #endregion

        #region CONSTRUCTORS
        public Character()
        {
            
        }

        #endregion

        #region METHODS


        #endregion
    }
}
