using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private List<Item> _items;
        private int _northLocation;
        private int _eastLocation;
        private int _southLocation;
        private int _westLocation;

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
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
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
        #endregion

        #region CONSTRUCTORS

        public Location()
        {

        }

        #endregion

        #region METHODS



        #endregion

    }
}
