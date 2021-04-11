using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;

namespace TBQuestGame.BusinessLayer
{
    class PlayerRepository : IDisposable
    {
        private DataServiceXml _dataService = new DataServiceXml();
        List<Player> _player = new List<Player>();

        public PlayerRepository()
        {
            try
            {
                _player = _dataService.ReadPlayer() as List<Player>;
            }
            catch (Exception)
            {
                //throw;
            }
        }
        public Player GetPlayer()
        {
            return _player[0];
        }
        public void SavePlayer(Player player)
        {
            try
            {
                _player.Clear();
                _player.Add(player);
                _dataService.WritePlayer(_player);
            }
            catch (Exception)
            {
                //throw;
            }

        }
        public void Dispose()
        {
            _dataService = null;
            _player = null;
        }
    }
}
