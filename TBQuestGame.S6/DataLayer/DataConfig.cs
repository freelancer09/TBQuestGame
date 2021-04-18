using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public class DataConfig
    {
        public static string DataPathPlayer => @"DataLayer\Player.xml";
        public static string DataPathMap => @"DataLayer\Map.xml";
        public static string DataPathLog => @"DataLayer\Log.xml";
    }
}
