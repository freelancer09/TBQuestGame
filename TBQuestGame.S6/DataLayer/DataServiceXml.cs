using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using System.Collections.ObjectModel;

namespace TBQuestGame.DataLayer
{    
    public class DataServiceXml
    {
        private string _dataFilePath;
        private string _dataFileMap;
        private string _dataFileLog;

        public IEnumerable<Player> ReadPlayer()
        {
            List<Player> player = new List<Player>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Player>), new[] { typeof(Food), typeof(Book) });
            try
            {
                StreamReader reader = new StreamReader(_dataFilePath);
                using (reader)
                {
                    player = (List<Player>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return player;
        }
        public void WritePlayer(IEnumerable<Player> player)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Player>), new[] { typeof(Food), typeof(Book) });
            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    serializer.Serialize(writer, player);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Map> ReadMap()
        {
            List<Map> map = new List<Map>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Map>), new[] { typeof(Location), typeof(Food), typeof(Book) });
            try
            {
                StreamReader reader = new StreamReader(_dataFileMap);
                using (reader)
                {
                    map = (List<Map>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return map;
        }
        public void WriteMap(IEnumerable<Map> map)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Map>), new[] { typeof(Location), typeof(Food), typeof(Book) });
            try
            {
                StreamWriter writer = new StreamWriter(_dataFileMap);
                using (writer)
                {
                    serializer.Serialize(writer, map);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<string> ReadLog()
        {
            List<string> log = new List<string>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            try
            {
                StreamReader reader = new StreamReader(_dataFileLog);
                using (reader)
                {
                    log = (List<string>)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return log;
        }
        public void WriteLog(IEnumerable<string> log)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            try
            {
                StreamWriter writer = new StreamWriter(_dataFileLog);
                using (writer)
                {
                    serializer.Serialize(writer, log);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataServiceXml()
        {
            _dataFilePath = DataConfig.DataPathPlayer;
            _dataFileMap = DataConfig.DataPathMap;
            _dataFileLog = DataConfig.DataPathLog;
        }
    }
}
