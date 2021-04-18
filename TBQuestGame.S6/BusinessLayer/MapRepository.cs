using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;

namespace TBQuestGame.BusinessLayer
{
    class MapRepository : IDisposable
    {
        private DataServiceXml _dataService = new DataServiceXml();
        List<Map> _map = new List<Map>();

        public MapRepository()
        {
            try
            {
                _map = _dataService.ReadMap() as List<Map>;
            }
            catch (Exception)
            {
                //throw;
            }
        }
        public Map GetMap()
        {
            return _map[0];
        }
        public void SaveMap(Map map)
        {
            try
            {
                _map.Clear();
                _map.Add(map);
                _dataService.WriteMap(_map);
            }
            catch (Exception)
            {
                //throw;
            }

        }
        public void Dispose()
        {
            _dataService = null;
            _map = null;
        }
    }
}
