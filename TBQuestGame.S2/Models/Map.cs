using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Map
    {

        #region ENUMS

        #endregion

        #region FIELDS

        private List<Location> _locations;
        private Location _currentLocation;

        #endregion

        #region PROPERTIES

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Map()
        {
            _locations = new List<Location>();
        }

        #endregion

        #region METHODS

        public void Move(Location location)
        {
            _currentLocation = location;
        }
        public Location NorthLocation()
        {
            Location northLocation = null;

            foreach (Location location in Locations)
            {
                if (location.Id == _currentLocation.NorthLocation)
                {
                    northLocation = location;
                }
            }
            return northLocation;
        }
        public Location EastLocation()
        {
            Location eastLocation = null;

            foreach (Location location in Locations)
            {
                if (location.Id == _currentLocation.EastLocation)
                {
                    eastLocation = location;
                }
            }
            return eastLocation;
        }
        public Location SouthLocation()
        {
            Location southLocation = null;

            foreach (Location location in Locations)
            {
                if (location.Id == _currentLocation.SouthLocation)
                {
                    southLocation = location;
                }
            }
            return southLocation;
        }
        public Location WestLocation()
        {
            Location westLocation = null;

            foreach (Location location in Locations)
            {
                if (location.Id == _currentLocation.WestLocation)
                {
                    westLocation = location;
                }
            }
            return westLocation;
        }
        public Location GetLocation(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.Id == id)
                {
                    return location;
                }
            }
            return null;
        }

        #endregion

    }
}
