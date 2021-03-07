using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "NewPlayer",
                Job = Player.JobTitle.Student,
                SkillEnglish = 0,
                SkillHistory = 0,
                SkillMath = 0,
                SkillPhysical = 0,
                SkillScience = 0,
                LocationId = 0,
                Stamina = 100,
                Money = 0
            };
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "This is the first initial message!",
                "This is another example message. Pretty cool huh?"
            };
        }
    }
}
