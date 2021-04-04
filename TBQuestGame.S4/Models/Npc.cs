using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Npc : Character, ITrade, ISpeak
    {
        #region ENUMS

        #endregion

        #region FIELDS

        protected ObservableCollection<GameItem> _inventory;
        private bool _tradeable;
        private bool _talkable;
        private List<string> _dialogue;
        private int _conversation;
        private string _skill;

        #endregion

        #region PROPERTIES        
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public bool Tradeable
        {
            get { return _tradeable; }
            set { _tradeable = value; }
        } 
        public bool Talkable
        {
            get { return _talkable; }
            set { _talkable = value; }
        }
        public List<string> Dialogue
        {
            get { return _dialogue; }
            set { _dialogue = value; }
        }
        public int Conversation
        {
            get { return _conversation; }
            set { _conversation = value; }
        }
        public string Skill
        {
            get { return _skill; }
            set { _skill = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Npc()
        {
            _inventory = new ObservableCollection<GameItem>();
        }
        public Npc(int id, string name, Character.JobTitle job, bool talkable, bool tradeable)
        {
            _id = id;
            _name = name;
            _job = job;
            _inventory = new ObservableCollection<GameItem>();
            _talkable = talkable;
            _tradeable = tradeable;
            _conversation = 0;
        }
        #endregion

        #region METHODS

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) Inventory.Add(selectedGameItem);
        }
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) Inventory.Remove(selectedGameItem);
        }

        public string RandomDialogue()
        {
            if (this.Dialogue != null)
            {
                return Dialogue[random.Next(0, Dialogue.Count())];
            }
            else
            {
                return "";
            }
        }
        public string NextDialogue()
        {
            if (Conversation < Dialogue.Count())
            {
                Conversation++;
                return Dialogue[Conversation - 1];                
            }
            else return "";
        }
        #endregion
    }
}
