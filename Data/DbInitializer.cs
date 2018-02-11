using System.Linq;
using LCARS.Models;

namespace LCARS.Data
{
    public class DbInitializer
    {
        public static void Initialize(GameContext db)
        {
            db.Database.EnsureCreated();

            if (db.Characters.Any()) return;

            var skills = new[]
            {
                new Skill {SkillId = 1, Name = "Command"},
                new Skill {SkillId = 2, Name = "Engineering"},
                new Skill {SkillId = 3, Name = "Piloting"},
                new Skill {SkillId = 4, Name = "Science"},
                new Skill {SkillId = 5, Name = "Skill Needed"},
                new Skill {SkillId = 6, Name = "Weapons"}
            };
            db.Skills.AddRange(skills);
            db.SaveChanges();

            var characters = new[]
            {
                new Character { CharacterId = 1 , Name = "Randy Hardthrottle", Password = "9783", Role = "Roboticist" },
                new Character { CharacterId = 2 , Name = "Andromeda Galaxia", Password = "0522", Role = "Diplomat" },
                new Character { CharacterId = 3 , Name = "Bisquette Stickson", Password = "0576", Role = "First Officer" },
                new Character { CharacterId = 4 , Name = "Oxy Clean", Password = "0224", Role = "Atmospherics Tech" },
                new Character { CharacterId = 5 , Name = "Jilshey Chompson", Password = "1962", Role = "Chef" },
                new Character { CharacterId = 6 , Name = "Dr. Ed", Password = "6969", Role = "Chief Veterinarian" },
                new Character { CharacterId = 7 , Name = "Wrench Thornbody", Password = "9431", Role = "4th Chief Engineer" },
                new Character { CharacterId = 8 , Name = "Dr. Snapson", Password = "9374", Role = "Research Director" },
                new Character { CharacterId = 9 , Name = "Weltall Stutzer", Password = "7777", Role = "Space Dandy" },
                new Character { CharacterId = 10 , Name = "Gristle Bonerum", Password = "2001", Role = "ISAAC Representative" },
                new Character { CharacterId = 11 , Name = "Chuck Splinthair", Password = "8008", Role = "Tactical Officer" },
                new Character { CharacterId = 12 , Name = "Carmen Floordeck", Password = "1110", Role = "Security Officer" },
                new Character { CharacterId = 13 , Name = "B.E.E.F.", Password = "712", Role = "Android" },
                new Character { CharacterId = 14 , Name = "Ol' Rusty", Password = "3644", Role = "Mawg" },
                new Character { CharacterId = 15 , Name = "Guy Trustworthy", Password = "4019", Role = "Syndicate Agent" },
                new Character { CharacterId = 16 , Name = "Bobbi Johnson", Password = "8665", Role = "Helmsman" },
                new Character { CharacterId = 17 , Name = "Ahsat Ray", Password = "3844", Role = "Security Guard" },
                new Character { CharacterId = 18 , Name = "Dr. Kleiner", Password = "5737", Role = "Lab Assistant" },
                new Character { CharacterId = 19 , Name = "Redd Shirt", Password = "5283", Role = "Junior Officer" },
                new Character { CharacterId = 20 , Name = "Fix McRunfast", Password = "3425", Role = "Engineer" }
            };
            db.Characters.AddRange(characters);
            db.SaveChanges();

            var characterSkills = new[]
            {
                new CharacterSkill {CharacterSkillId = 1, CharacterId = 1, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 2, CharacterId = 2, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 3, CharacterId = 3, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 4, CharacterId = 4, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 5, CharacterId = 5, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 6, CharacterId = 6, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 7, CharacterId = 7, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 8, CharacterId = 8, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 9, CharacterId = 9, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 10, CharacterId = 10, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 11, CharacterId = 11, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 12, CharacterId = 12, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 13, CharacterId = 13, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 14, CharacterId = 14, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 15, CharacterId = 15, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 16, CharacterId = 16, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 17, CharacterId = 17, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 18, CharacterId = 18, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 19, CharacterId = 19, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 20, CharacterId = 20, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 21, CharacterId = 1, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 22, CharacterId = 2, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 23, CharacterId = 3, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 24, CharacterId = 4, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 25, CharacterId = 5, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 26, CharacterId = 6, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 27, CharacterId = 7, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 28, CharacterId = 8, SkillId = 4},
                new CharacterSkill {CharacterSkillId = 29, CharacterId = 9, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 30, CharacterId = 10, SkillId = 2},
                new CharacterSkill {CharacterSkillId = 31, CharacterId = 11, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 32, CharacterId = 12, SkillId = 1},
                new CharacterSkill {CharacterSkillId = 33, CharacterId = 13, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 34, CharacterId = 14, SkillId = 3},
                new CharacterSkill {CharacterSkillId = 35, CharacterId = 15, SkillId = 6}
            };
            db.CharacterSkills.AddRange(characterSkills);
            db.SaveChanges();

            var characterObjectives = new[]
            {
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 1, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 1, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 1, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 1, ObjectiveId = 4},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 1, ObjectiveId = 5},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 2, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 2, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 2, ObjectiveId = 6},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 2, ObjectiveId = 7},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 2, ObjectiveId = 8},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 3, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 3, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 3, ObjectiveId = 9},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 3, ObjectiveId = 10},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 3, ObjectiveId = 11},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 4, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 4, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 4, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 4, ObjectiveId = 12},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 4, ObjectiveId = 13},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 6},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 14},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 15},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 9},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 16},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 17},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 18},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 19},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 20},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 21},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 22},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 23},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 21},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 24},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 25},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 18},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 30},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 27},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 6},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 21},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 9},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 28},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 29},

                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 5, ObjectiveId = 18},
            };
            db.CharacterObjectives.AddRange(characterObjectives);
            db.SaveChanges();

            var locations = new[]
            {
                new Location { LocationId = 1, Name = "Bridge" },
                new Location { LocationId = 2, Name = "Communications" },
                new Location { LocationId = 3, Name = "Engineering Bay" },
                new Location { LocationId = 4, Name = "Medical Bay" },
                new Location { LocationId = 5, Name = "Science Wing" },
                new Location { LocationId = 6, Name = "Security Wing" },
                new Location { LocationId = 7, Name = "Logistics" }
            };
            db.Locations.AddRange(locations);
            db.SaveChanges();

            var action = new[]
            {
                new Action { ActionId = 1, Name = "Helm", SkillId = 3, LocationId = 1},
                new Action { ActionId = 1, Name = "Battle Stations", SkillId = 6, LocationId = 1},
                new Action { ActionId = 1, Name = "Point Defense Systems", SkillId = 6, LocationId = 1},
                new Action { ActionId = 1, Name = "Short Range Scanners", SkillId = 4, LocationId = 2},
                new Action { ActionId = 1, Name = "Long Range Scanners", SkillId = 4, LocationId = 2},
                new Action { ActionId = 1, Name = "Requisition Line", SkillId = 1, LocationId = 2},
                new Action { ActionId = 1, Name = "Mech Bay", SkillId = 2, LocationId = 3},
                new Action { ActionId = 1, Name = "Repair Drone Control", SkillId = 3, LocationId = 3},
                new Action { ActionId = 1, Name = "Atmospherics", SkillId = 2, LocationId = 3},
                new Action { ActionId = 1, Name = "Slip Drive", LocationId = 3},
                new Action { ActionId = 1, Name = "Auto Doc", LocationId = 4},
                new Action { ActionId = 1, Name = "Crew Records", SkillId = 1, LocationId = 4},
                new Action { ActionId = 1, Name = "Cloning Pods", LocationId = 4},
                new Action { ActionId = 1, Name = "Research Lab", SkillId = 4, LocationId = 5},
                new Action { ActionId = 1, Name = "Xenobiology", SkillId = 4, LocationId = 5},
                new Action { ActionId = 1, Name = "Robotics", SkillId = 2, LocationId = 5},
                new Action { ActionId = 1, Name = "Lockdown Station", SkillId = 1, LocationId = 6},
                new Action { ActionId = 1, Name = "Security Report", SkillId = 1, LocationId = 6},
                new Action { ActionId = 1, Name = "Security Drone Control", SkillId = 3, LocationId = 6},
                new Action { ActionId = 1, Name = "Cargo Bay", LocationId = 7},
                new Action { ActionId = 1, Name = "Armory", LocationId = 7},
                new Action { ActionId = 1, Name = "Mining Drone Control", SkillId = 3, LocationId = 7},
                new Action { ActionId = 1, Name = "Defend Self", LocationId = 8},
                new Action { ActionId = 1, Name = "Fight Aliens", SkillId = 6, LocationId = 8},
                new Action { ActionId = 1, Name = "Patch Station", LocationId = 8},
                new Action { ActionId = 1, Name = "Repair Station", SkillId = 2, LocationId = 8},
            };
            db.Actions.AddRange(action);
            db.SaveChanges();
        }
    }
}
