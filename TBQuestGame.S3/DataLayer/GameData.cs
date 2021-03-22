using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

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
                MaxStamina = 100,
                Money = 0,
                Inventory = InitialGameItems()
            };
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "This is another example message. Pretty cool huh?",
                "This is the first initial message!"
            };
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Book(1001, "Chemistry Book", "It's very old.", 20, "Science", 5, false),
                new Book(1002, "Algebra Book", "I hate math.", 20, "Math", 5, false),
                new Food(2001, "Bag of pretzels", "It's a very small bag", 2, "Stamina", 5, 1),
                new Food(2002, "Energy Drink", "24oz of pure energy", 5, "Stamina", 5, 5)
            };
        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        public static ObservableCollection<GameItem> InitialGameItems()
        {
            return new ObservableCollection<GameItem>()
            {
                GameItemById(2001),
                GameItemById(1002)
            };
        }
        public static int InitialGameMapLocation()
        { 
            return 1;
        }

        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations.Add(new Location() 
            { 
                Id = 1, 
                Name = "Parking Lot", 
                Description = "A small parking lot outside the main entrance.", 
                Accessible = true,
                WestLocation = 2,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(1001),
                    GameItemById(2002)
                }
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 2,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 3,
                EastLocation = 1,
                SouthLocation = 5,
                WestLocation = 6
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 3,
                Name = "Gym",
                Description = "Smells faintly of sweat.",
                Accessible = true,
                NorthLocation = 4,
                SouthLocation = 2
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 4,
                Name = "Football Field",
                Description = "It's a beautiful sunny day.",
                Accessible = true,
                SouthLocation = 3
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 5,
                Name = "Lunchroom",
                Description = "Meatloaf again.",
                Accessible = true,
                NorthLocation = 2
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 6,
                Name = "Hallway",
                Description = "A long hallway",
                Accessible = true,
                NorthLocation = 7,
                EastLocation = 2,
                WestLocation = 8
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 7,
                Name = "Office",
                Description = "The principal isn't here.",
                Accessible = true,
                SouthLocation = 6
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 8,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 9,
                EastLocation = 6,
                WestLocation = 29
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 9,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 11,
                SouthLocation = 8,
                WestLocation = 10
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 10,
                Name = "Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                EastLocation = 9
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 11,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 14,
                EastLocation = 13,
                SouthLocation = 9,
                WestLocation = 12
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 12,
                Name = "Classroom",
                Description = "An empty classsrooom.",
                Accessible = true,
                EastLocation = 11
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 13,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                WestLocation = 11
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 14,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                SouthLocation = 11,
                WestLocation = 15
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 15,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 16,
                EastLocation = 14,
                WestLocation = 17
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 16,
                Name = "Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                SouthLocation = 15
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 17,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 18,
                EastLocation = 15,
                WestLocation = 19
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 18,
                Name = "Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                SouthLocation = 17
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 19,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                EastLocation = 17,
                SouthLocation = 20
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 20,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 19,
                EastLocation = 22,
                SouthLocation = 23,
                WestLocation = 21
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 21,
                Name = "Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                EastLocation = 20
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 22,
                Name = "Classrom",
                Description = "An empty classroom.",
                Accessible = true,
                WestLocation = 20
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 23,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 20,
                EastLocation = 25,
                SouthLocation = 26,
                WestLocation = 24
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 24,
                Name = "Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                EastLocation = 23
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 25,
                Name = "Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                WestLocation = 23
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 26,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                NorthLocation = 23,
                EastLocation = 27
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 27,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                EastLocation = 29,
                SouthLocation = 28,
                WestLocation = 26
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 28,
                Name = "Library",
                Description = "That's a lot of books.",
                Accessible = true,
                NorthLocation = 27,
                EastLocation = 30
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 29,
                Name = "Hallway",
                Description = "A long hallway.",
                Accessible = true,
                EastLocation = 8,
                SouthLocation = 30,
                WestLocation = 27
            });
            gameMap.Locations.Add(new Location()
            {
                Id = 30,
                Name = "Computer Lab",
                Description = "Access to the information super highway.",
                Accessible = true,
                NorthLocation = 29,
                WestLocation = 28
            });
            return gameMap;
        }
    }
}
