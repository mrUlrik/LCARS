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

            var objectives = new[]
            {
                new Objective { ObjectiveId = 1, Title = "Voyager Home", Description = "Guide the USS Exeter through the Slipgate!" },
                new Objective { ObjectiveId = 2, Title = "First Generation", Description = "Survive the adventure." },
                new Objective { ObjectiveId = 3, Title = "O Captain", Description = "Find out who killed the captain." },
                new Objective { ObjectiveId = 4, Title = "Part Scavenger", Description = "You sabotaged the Life Support systems. No more than two people can know you did it." },
                new Objective { ObjectiveId = 5, Title = "Go, My Minions!", Description = "At any point during the adventure, have at least two drones of each type." },
                new Objective { ObjectiveId = 6, Title = "Core First", Description = "Find out who sabotaged the Slip Drive." },
                new Objective { ObjectiveId = 7, Title = "Strawman Argument", Description = "Never let the ship run away from a hostile alien ship." },
                new Objective { ObjectiveId = 8, Title = "Diplomacy Achieved", Description = "Blow up a friendly alien ship." },
                new Objective { ObjectiveId = 9, Title = "Bleeding Heart", Description = "Save all non-Mangalorian species you can, despite the Prime Directive. You can fail this once." },
                new Objective { ObjectiveId = 10, Title = "Stardate 420", Description = "End the adventure with \"Space Weed\" researched." },
                new Objective { ObjectiveId = 11, Title = "I'm The Captain Now", Description = "At least two of the Chief Engineer, Chief Veterinarian, and ISAAC Representative die at least once." },
                new Objective { ObjectiveId = 12, Title = "Breathe Easy", Description = "Two different rooms hit maximum Life Support capacity at any point during the adventure." },
                new Objective { ObjectiveId = 13, Title = "Choke on That, Nerds", Description = "You sabotaged the Slipdrive Core. Make sure no more than two people find out." },
                new Objective { ObjectiveId = 14, Title = "First Class Dining", Description = "Exterminate the Schmii species." },
                new Objective { ObjectiveId = 15, Title = "Nanor Surprise", Description = "End the adventure with Black Velanese Truffles in cargo." },
                new Objective { ObjectiveId = 16, Title = "Galaxial Healthcare", Description = "End the adventure with less than half the crew being injured. ... dead's OK, though." },
                new Objective { ObjectiveId = 17, Title = "Veteran Veterinarian", Description = "End the adventure with the Auto Doc damaged." },
                new Objective { ObjectiveId = 18, Title = "Prime Directive", Description = "Resolve never to interfere with alien life, whether helping or harming them. You can fail this once." },
                new Objective { ObjectiveId = 19, Title = "No Acting the Mickey", Description = "End the adventure with three players in Lockdown." },
                new Objective { ObjectiveId = 20, Title = "Freezy Pops", Description = "You sabotaged the Cryo Station. Make sure no more than two people find out." },
                new Objective { ObjectiveId = 21, Title = "Future Democracy", Description = "Destroy all alien species you can, when given the opportunity. You can fail this once." },
                new Objective { ObjectiveId = 22, Title = "For Science!", Description = "The ship completes at least three Research Upgrades." },
                new Objective { ObjectiveId = 23, Title = "Harmless Experiment", Description = "You killed the Captain. Make sure no more than two people find out." },
                new Objective { ObjectiveId = 24, Title = "The Booty, Baby", Description = "When the ship is in the same sector as BooBies, spend one round in the bar doing nothing." },
                new Objective { ObjectiveId = 25, Title = "Stay Dandy, Baby", Description = "Get kicked out of three rooms due to Life Support overload." },
                new Objective { ObjectiveId = 26, Title = "I'm The Captain Now", Description = "At least two of the First Officer, Tactical Officer, and Mawg survive without dying once." },
                new Objective { ObjectiveId = 27, Title = "No Red Tape", Description = "You sabotaged the Crew Records. Make sure no more than two people find out." },
                new Objective { ObjectiveId = 28, Title = "Gone to Plaid", Description = "" },
                new Objective { ObjectiveId = 29, Title = "Use the Schwartz", Description = "" },
                new Objective { ObjectiveId = 30, Title = "Unnamed", Description = "At least two of the First Officer, Tactical Officer, and Mawg survive without dying once." }
            };
            db.Objectives.AddRange(objectives);
            db.SaveChanges();

            var characterObjectives = new[]
            {
                new CharacterObjective { CharacterObjectiveId = 1, CharacterId = 1, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 2, CharacterId = 1, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 3, CharacterId = 1, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 4, CharacterId = 1, ObjectiveId = 4},
                new CharacterObjective { CharacterObjectiveId = 5, CharacterId = 1, ObjectiveId = 5},

                new CharacterObjective { CharacterObjectiveId = 6, CharacterId = 2, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 7, CharacterId = 2, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 8, CharacterId = 2, ObjectiveId = 6},
                new CharacterObjective { CharacterObjectiveId = 9, CharacterId = 2, ObjectiveId = 7},
                new CharacterObjective { CharacterObjectiveId = 10, CharacterId = 2, ObjectiveId = 8},

                new CharacterObjective { CharacterObjectiveId = 11, CharacterId = 3, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 12, CharacterId = 3, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 13, CharacterId = 3, ObjectiveId = 9},
                new CharacterObjective { CharacterObjectiveId = 14, CharacterId = 3, ObjectiveId = 10},
                new CharacterObjective { CharacterObjectiveId = 15, CharacterId = 3, ObjectiveId = 11},

                new CharacterObjective { CharacterObjectiveId = 16, CharacterId = 4, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 17, CharacterId = 4, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 18, CharacterId = 4, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 19, CharacterId = 4, ObjectiveId = 12},
                new CharacterObjective { CharacterObjectiveId = 20, CharacterId = 4, ObjectiveId = 13},

                new CharacterObjective { CharacterObjectiveId = 21, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 22, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 23, CharacterId = 5, ObjectiveId = 6},
                new CharacterObjective { CharacterObjectiveId = 24, CharacterId = 5, ObjectiveId = 14},
                new CharacterObjective { CharacterObjectiveId = 25, CharacterId = 5, ObjectiveId = 15},

                new CharacterObjective { CharacterObjectiveId = 26, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 27, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 28, CharacterId = 5, ObjectiveId = 9},
                new CharacterObjective { CharacterObjectiveId = 29, CharacterId = 5, ObjectiveId = 16},
                new CharacterObjective { CharacterObjectiveId = 30, CharacterId = 5, ObjectiveId = 17},

                new CharacterObjective { CharacterObjectiveId = 31, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 32, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 33, CharacterId = 5, ObjectiveId = 18},
                new CharacterObjective { CharacterObjectiveId = 34, CharacterId = 5, ObjectiveId = 19},
                new CharacterObjective { CharacterObjectiveId = 35, CharacterId = 5, ObjectiveId = 20},

                new CharacterObjective { CharacterObjectiveId = 36, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 37, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 38, CharacterId = 5, ObjectiveId = 21},
                new CharacterObjective { CharacterObjectiveId = 39, CharacterId = 5, ObjectiveId = 22},
                new CharacterObjective { CharacterObjectiveId = 40, CharacterId = 5, ObjectiveId = 23},

                new CharacterObjective { CharacterObjectiveId = 41, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 42, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 43, CharacterId = 5, ObjectiveId = 21},
                new CharacterObjective { CharacterObjectiveId = 44, CharacterId = 5, ObjectiveId = 24},
                new CharacterObjective { CharacterObjectiveId = 45, CharacterId = 5, ObjectiveId = 25},

                new CharacterObjective { CharacterObjectiveId = 46, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 47, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 48, CharacterId = 5, ObjectiveId = 18},
                new CharacterObjective { CharacterObjectiveId = 49, CharacterId = 5, ObjectiveId = 30},
                new CharacterObjective { CharacterObjectiveId = 50, CharacterId = 5, ObjectiveId = 27},

                new CharacterObjective { CharacterObjectiveId = 51, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 52, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 53, CharacterId = 5, ObjectiveId = 6},

                new CharacterObjective { CharacterObjectiveId = 54, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 55, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 56, CharacterId = 5, ObjectiveId = 21},

                new CharacterObjective { CharacterObjectiveId = 57, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 58, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 59, CharacterId = 5, ObjectiveId = 9},

                new CharacterObjective { CharacterObjectiveId = 60, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 61, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 62, CharacterId = 5, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 63, CharacterId = 5, ObjectiveId = 28},
                new CharacterObjective { CharacterObjectiveId = 64, CharacterId = 5, ObjectiveId = 29},

                new CharacterObjective { CharacterObjectiveId = 65, CharacterId = 5, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 66, CharacterId = 5, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 67, CharacterId = 5, ObjectiveId = 18},
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
                new Location { LocationId = 7, Name = "Logistics" },
                new Location { LocationId = 8, Name = "" }
            };
            db.Locations.AddRange(locations);
            db.SaveChanges();

            var attributes = new[]
            {
                new Attribute { AttributeId = 1, Name = "Helm", SkillId = 3, LocationId = 1},
                new Attribute { AttributeId = 2, Name = "Battle Stations", SkillId = 6, LocationId = 1},
                new Attribute { AttributeId = 3, Name = "Point Defense Systems", SkillId = 6, LocationId = 1},
                new Attribute { AttributeId = 4, Name = "Short Range Scanners", SkillId = 4, LocationId = 2},
                new Attribute { AttributeId = 5, Name = "Long Range Scanners", SkillId = 4, LocationId = 2},
                new Attribute { AttributeId = 6, Name = "Requisition Line", SkillId = 1, LocationId = 2},
                new Attribute { AttributeId = 7, Name = "Mech Bay", SkillId = 2, LocationId = 3},
                new Attribute { AttributeId = 8, Name = "Repair Drone Control", SkillId = 3, LocationId = 3},
                new Attribute { AttributeId = 9, Name = "Atmospherics", SkillId = 2, LocationId = 3},
                new Attribute { AttributeId = 10, Name = "Slip Drive", LocationId = 3},
                new Attribute { AttributeId = 11, Name = "Auto Doc", LocationId = 4},
                new Attribute { AttributeId = 12, Name = "Crew Records", SkillId = 1, LocationId = 4},
                new Attribute { AttributeId = 13, Name = "Cloning Pods", LocationId = 4},
                new Attribute { AttributeId = 14, Name = "Research Lab", SkillId = 4, LocationId = 5},
                new Attribute { AttributeId = 15, Name = "Xenobiology", SkillId = 4, LocationId = 5},
                new Attribute { AttributeId = 16, Name = "Robotics", SkillId = 2, LocationId = 5},
                new Attribute { AttributeId = 17, Name = "Lockdown Station", SkillId = 1, LocationId = 6},
                new Attribute { AttributeId = 18, Name = "Security Report", SkillId = 1, LocationId = 6},
                new Attribute { AttributeId = 19, Name = "Security Drone Control", SkillId = 3, LocationId = 6},
                new Attribute { AttributeId = 20, Name = "Cargo Bay", LocationId = 7},
                new Attribute { AttributeId = 21, Name = "Armory", LocationId = 7},
                new Attribute { AttributeId = 22, Name = "Mining Drone Control", SkillId = 3, LocationId = 7},
                new Attribute { AttributeId = 23, Name = "Defend Self", LocationId = 8},
                new Attribute { AttributeId = 24, Name = "Fight Aliens", SkillId = 6, LocationId = 8},
                new Attribute { AttributeId = 25, Name = "Patch Station", LocationId = 8},
                new Attribute { AttributeId = 26, Name = "Repair Station", SkillId = 2, LocationId = 8},
            };
            db.Attributes.AddRange(attributes);
            db.SaveChanges();
        }
    }
}
