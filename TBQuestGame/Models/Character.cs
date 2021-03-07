using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class Character
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
        protected int _locationId;
        protected JobTitle _job;

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
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
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
        public Character(int id, string name, int locationId)
        {
            _id = id;
            _name = name;
            _locationId = locationId;
        }
        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name}.";
        }
        public abstract int Location();

        #endregion
    }
}
