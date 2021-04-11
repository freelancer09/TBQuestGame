using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;

namespace TBQuestGame.BusinessLayer
{
    public class PlayerBusiness
    {
        public FileIoMessage FileIoStatus { get; set; }

        public Player GetPlayer()
        {
            Player player = null;
            FileIoStatus = FileIoMessage.None;

            try
            {
                using (PlayerRepository playerRepository = new PlayerRepository())
                {
                    player = playerRepository.GetPlayer();
                };
                if (player != null)
                {
                    FileIoStatus = FileIoMessage.Complete;
                }
                else
                {
                    FileIoStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
            return player;
        }
        public void SavePlayer(Player player)
        {
            try
            {
                if (player != null)
                {
                    using (PlayerRepository playerRepository = new PlayerRepository())
                    {
                        playerRepository.SavePlayer(player);
                    };
                    FileIoStatus = FileIoMessage.Complete;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
        }
        public Map GetMap()
        {
            Map map = null;
            FileIoStatus = FileIoMessage.None;

            try
            {
                using (MapRepository mapRepository = new MapRepository())
                {
                    map = mapRepository.GetMap();
                };
                if (map != null)
                {
                    FileIoStatus = FileIoMessage.Complete;
                }
                else
                {
                    FileIoStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
            return map;
        }
        public void SaveMap(Map map)
        {
            try
            {
                if (map != null)
                {
                    using (MapRepository mapRepository = new MapRepository())
                    {
                        mapRepository.SaveMap(map);
                    };
                    FileIoStatus = FileIoMessage.Complete;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
        }
        public List<string> GetLog()
        {
            List<string> log = null;
            FileIoStatus = FileIoMessage.None;

            try
            {
                using (LogRepository logRepository = new LogRepository())
                {
                    log = logRepository.GetLog();
                };
                if (log != null)
                {
                    FileIoStatus = FileIoMessage.Complete;
                }
                else
                {
                    FileIoStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
            return log;
        }
        public void SaveLog(List<string> log)
        {
            try
            {
                if (log != null)
                {
                    using (LogRepository logRepository = new LogRepository())
                    {
                        logRepository.SaveLog(log);
                    };
                    FileIoStatus = FileIoMessage.Complete;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
        }
    }
}
