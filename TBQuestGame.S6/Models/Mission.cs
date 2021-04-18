using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Mission : ObservableObject
    {

        #region FIELDS

        public const int SKILL_NEEDED = 10;
        private int _id;
        private string _name;
        private string _description;
        private string _skillNeeded;
        private GameItem _reward;
        private bool _done;

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
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string SkillNeeded
        {
            get { return _skillNeeded; }
            set { _skillNeeded = value; }
        }
        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }
        public GameItem Reward
        {
            get { return _reward; }
            set { _reward = value; }
        }        
        public string MissionStatus
        {
            get { return Status(); }
        }

        #endregion

        #region CONSTRUCTORS

        public Mission()
        {

        }
        public Mission(int id, string name, string description, string skillNeeded, GameItem reward, bool done = false)
        {
            Id = id;
            Name = name;
            Description = description;
            SkillNeeded = skillNeeded;
            Reward = reward;
            Done = done;
        }

        #endregion

        #region METHODS        

        public string Status()
        {
            if (_done) return "Complete";
            else return "Incomplete";
        }

        #endregion
    }
}
