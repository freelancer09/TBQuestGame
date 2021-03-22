using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Location
    {

        #region ENUMS

        #endregion

        #region FIELDS

        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _northLocation;
        private int _eastLocation;
        private int _southLocation;
        private int _westLocation;
        private ObservableCollection<GameItem> _gameItems;

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
        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }
        public int NorthLocation
        {
            get { return _northLocation; }
            set { _northLocation = value; }
        }
        public int EastLocation
        {
            get { return _eastLocation; }
            set { _eastLocation = value; }
        }
        public int SouthLocation
        {
            get { return _southLocation; }
            set { _southLocation = value; }
        }
        public int WestLocation
        {
            get { return _westLocation; }
            set { _westLocation = value; }
        }
        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();
            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }
            GameItems.Clear();
            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }
        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) _gameItems.Add(selectedGameItem);
            UpdateLocationGameItems();
        }
        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null) _gameItems.Remove(selectedGameItem);
            UpdateLocationGameItems();
        }

        #endregion

    }
}
