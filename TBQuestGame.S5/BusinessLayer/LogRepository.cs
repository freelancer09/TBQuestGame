using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;

namespace TBQuestGame.BusinessLayer
{
    class LogRepository : IDisposable
    {
        private DataServiceXml _dataService = new DataServiceXml();
        List<string> _log = new List<string>();

        public LogRepository()
        {
            try
            {
                _log = _dataService.ReadLog() as List<string>;
            }
            catch (Exception)
            {
                //throw;
            }
        }
        public List<string> GetLog()
        {
            return _log;
        }
        public void SaveLog(List<string> log)
        {
            try
            {
                _log.Clear();
                _log = log;
                _dataService.WriteLog(_log);
            }
            catch (Exception)
            {
                //throw;
            }

        }
        public void Dispose()
        {
            _dataService = null;
            _log = null;
        }
    }
}
