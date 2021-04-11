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
                Stamina = 100,
                MaxStamina = 100,
                Money = 20,
                Inventory = InitialGameItems()
            };
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "To make things even worse, it's finals week. Time to study!",
                "You've woken up in the school parking lot with a nasty bump on your head and seem to have forgotten everything you learned this semester!",
                "Welcome back to Little Lake High School."
            };
        }
        public static List<string> DefaultDialogue()
        {
            return new List<string>()
            {
                "How are you today?",
                "Crazy weather we've been having."
            };
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Book(1001, "Chemistry Book", "It's very old.", 20, "Science", 5, false),
                new Book(1002, "Geometry Book", "I wonder what the volume is?", 20, "Math", 5, false),
                new Book(1003, "History Book", "A thrilling history of ancient Rome.", 20, "History", 5, false),
                new Book(1004, "English Book", "A dummies guide to essay writing.", 20, "English", 5, false),
                new Book(1005, "Workout Tips", "A book describing proper workout techniques.", 20, "Physical", 5, false),
                new Book(1006, "Biology Book", "An encyclopedia of 2342 different fungi species.", 20, "Science", 5, false),
                new Book(1007, "Calculus Book", "Don't drink and derive.", 20, "Math", 5, false),

                new Food(2001, "Bag of pretzels", "It's a very small bag", 2, "Stamina", 5, 1),
                new Food(2002, "Energy Drink", "24oz of pure energy", 5, "Stamina", 5, 5)
            };
        }
        public static List<Npc> StandardNpcs()
        {
            return new List<Npc>()
            {
                new Npc(1001, "Librarian", Character.JobTitle.Faculty, true, true)
                {
                    Inventory = new ObservableCollection<GameItem>() 
                    { 
                        GameItemById(1001),
                        GameItemById(1002),
                        GameItemById(1003),
                        GameItemById(1004),
                        GameItemById(1005)
                    },
                    Dialogue = new List<string>()
                    {
                        "Reading is wonderful.",
                        "Why aren't you in class?"
                    }
                },
                new Npc(1002, "History Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "History",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1003)
                    },
                    Dialogue = new List<string>()
                    {
                        "The United States is 3.8 million square miles in size.",
                        "In the United States, July 4, 1776 is celebrated as Independence Day."
                    }
                },
                new Npc(1003, "Geometry Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "Math",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1002)
                    },
                    Dialogue = new List<string>()
                    {
                        "Pi is defined as the ratio of a circle's circumference to its diameter.",
                        "The earliest recorded beginnings of geometry can be traced to ancient Mesopotamia and Egypt in the 2nd millennium BC."
                    }
                },
                new Npc(1004, "Chemistry Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "Science",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1001)
                    },
                    Dialogue = new List<string>()
                    {
                        "The atom is the basic unit of chemistry.",
                        "The six naturally occurring noble gases are helium, neon, argon, krypton, xenon, and radon.",
                        "Neon is a chemical element with the symbol Ne and the atomic number 10.",
                        "A covalent bond is a chemical bond that involves the sharing of electron pairs between atoms."
                    }
                },
                new Npc(1005, "Gym Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "Physical",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1005)
                    },
                    Dialogue = new List<string>()
                    {
                        "Body mass index is a value derived from the mass and height of a person.",
                        "Tennis originated in the late 19th century."
                    }
                },
                new Npc(1006, "English Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "English",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1004)
                    },
                    Dialogue = new List<string>()
                    {
                        "A noun is a word that functions as the name of a specific object or set of objects.",
                        "William Shakespeare was born April 26, 1564."
                    }
                },
                new Npc(1007, "Biology Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "Science",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1006)
                    },
                    Dialogue = new List<string>()
                    {
                        "Chameleons' eyes are independently mobile.",
                        "The eight major taxonomic ranks are: Species, Genus, Family, Order, Class, Phylum, Kingdom, Domain, Life."
                    }
                },
                new Npc(1003, "Calculus Teacher", Character.JobTitle.Teacher, true, true)
                {
                    Skill = "Math",
                    Inventory = new ObservableCollection<GameItem>()
                    {
                        GameItemById(1007)
                    },
                    Dialogue = new List<string>()
                    {
                        "Calculus is the mathematical study of continuous change.",
                        "The process of finding a derivative is called differentiation."
                    }
                }
            };
        }
        public static List<Mission> StandardMissions()
        {
            return new List<Mission>()
            {
                new Mission(01, "Study Math", "Raise your math skill to 10", "Math", GameItemById(2001)),
                new Mission(02, "Study Science", "Raise your science skill to 10", "Science", GameItemById(2001)),
                new Mission(03, "Study English", "Raise your english skill to 10", "English", GameItemById(2001)),
                new Mission(04, "Study History", "Raise your history skill to 10", "History", GameItemById(2001)),
                new Mission(05, "Study Physical", "Raise your physical skill to 10", "Physical", GameItemById(2001))
            };
        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        private static Npc NpcById(int id)
        {
            return StandardNpcs().FirstOrDefault(i => i.Id == id);
        }
        private static Mission MissionById(int id)
        {
            return StandardMissions().FirstOrDefault(i => i.Id == id);
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
        public static ObservableCollection<Mission> InitialMissions()
        {
            return new ObservableCollection<Mission>()
            {
                MissionById(01),
                MissionById(02),
                MissionById(03),
                MissionById(04),
                MissionById(05)
            };
        }
        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.Locations.Add(new Location() 
            { 
                Id = 1, 
                Name = "Parking Lot", 
                Description = "A small parking lot outside the main entrance.", 
                Accessible = true,
                WestLocation = 2,
                GameItems = new ObservableCollection<GameItem>
                {
                    GameItemById(1001)
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
                SouthLocation = 2,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1005)
                }
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
                Name = "History Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                EastLocation = 9,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1002)
                }
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
                Name = "Geometry Classroom",
                Description = "An empty classsrooom.",
                Accessible = true,
                EastLocation = 11,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1003)
                }
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
                Name = "History Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                SouthLocation = 15,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1004)
                }
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
                Name = "English Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                SouthLocation = 17,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1006)
                }
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
                Name = "Calculus Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                EastLocation = 20,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1007)
                }
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
                Name = "Biology Classroom",
                Description = "An empty classroom.",
                Accessible = true,
                WestLocation = 23,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1007)
                }
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
                EastLocation = 30,
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1001)
                }
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
