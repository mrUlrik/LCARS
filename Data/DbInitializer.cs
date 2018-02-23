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

            var locations = new[]
            {
                new Location { LocationId = 1, Name = "Bridge", Abbreviated = "Bridge"},
                new Location { LocationId = 2, Name = "Communications", Abbreviated = "Comms" },
                new Location { LocationId = 3, Name = "Engineering Bay", Abbreviated = "Engineering" },
                new Location { LocationId = 4, Name = "Medical Bay", Abbreviated = "Medical" },
                new Location { LocationId = 5, Name = "Science Wing", Abbreviated = "Science" },
                new Location { LocationId = 6, Name = "Security Wing", Abbreviated = "Security" },
                new Location { LocationId = 7, Name = "Logistics", Abbreviated = "Logistics" },
            };
            db.Locations.AddRange(locations);
            db.SaveChanges();

            var characters = new[]
            {
                new Character
                {
                    CharacterId = 1,
                    Name = "Randy Hardthrottle",
                    Password = "9783",
                    Role = "Roboticist",
                    TraitName = "Drone Nut",
                    TraitDescription = "You can remotely use Drone Stations without having to teleport anywhere. Your Drone orders always take priority.",
                    Tips = "Once you get a few drones up you can kick back in the bar and let them do the work for you. You don't have to worry about people overriding your drone orders, either!",
                    Story = "Growing up on a colonial terraformed agricultural planet didn't stop Randy from pursuing his true interest--a love for machinery and gadgets. Though he started his career as a precocious ship ensign, Randy quickly shook off the stigma of a wunderkind and found himself assigned to the Exeter. Turns out a spaceship has a lot of spare parts--especially with all these stations laying around unused. Life Support Safety Protocols? That's stupid. This ship is stupid. Stripping that for parts won't hurt anybody, right? Besides, you have a sweet new drone n--oh, that one gained sentience again..."


                },
                new Character
                {
                    CharacterId = 2,
                    Name = "Andromeda Galaxia",
                    Password = "0522",
                    Role = "Diplomat",
                    TraitName = "Peace Negotiations",
                    TraitDescription = "You can fire missiles without having to teleport anywhere.",
                    Tips = "Your Trait isn't a typo. Hang out and liberally apply Space Diplomacy to any alien ships that show up. Your Tactical Officer (Rhett) will be working with you closely (but remember, his end goals might not align with yours!)",
                    Story = "Tina Johnson always wanted to go to space, but really only for one reason--to blow shit up. Unfortunately, due to an antagonistic, pacifist of a professor complaining about her blowing up a Andralli trading vessel (it had guns, I tell you), Tina never made it out of tactical university. However, as luck would have it, she stumbled upon \"How To Win An Alien's Heart in 30 Days\", a course-by-videotape instruction booklet. Changing her name to something more fitting, she acquired a job on the Exeter by masquerading as a diplomat. Tina--now Andromeda--would bring Space Diplomacy to the galaxy!"
                },
                new Character
                {
                    CharacterId = 3,
                    Name = "Bisquette Stickson",
                    Password = "0576",
                    Role = "First Officer",
                    TraitName = "Grow The Beard",
                    TraitDescription = "You can run Crew Reports, Security Reports, and use the Requistion Line without having to teleport anywhere.",
                    Tips = "You'll need to convince the Research Director to change research for you. Try and keep Science crew working on research and the lab open. Meanwhile, hang out in the Bar and get juicy gossip on the crew.",
                    Story = "Bisquette Stickson was catapulted immediately into the First Officer position onto the Exeter, but found it lacking. The captain never let him strut his stuff--only ordered him to bring him coffee, rub his feet, read him bedtime stories. The service was almost too humiliating to bear, but Stickson stuck with it, knowing he'd one day command the Exeter for his sevice--that is, before he found out he was 4th in line to take over captaincy of the vessel. He'd just have to do something about that..."
                },
                new Character
                {
                    CharacterId = 4,
                    Name = "Oxy Clean",
                    Password = "0224",
                    Role = "Atmospherics Tech",
                    TraitName = "Miracle Cleanser",
                    TraitDescription = "When you increase Life Support in a room, it goes up by an additional 1.",
                    Tips = "You are better at working the Atmospherics Station--try and keep track of areas where the crew needs to go and juice it up with Atmoline. Try and keep your sabotage of the Core on the down-low!",
                    Story = "Oxy--known as Ms. Clean to her friends--is a graduate of the Deep Inhalation Society. Ever the diligant worker, Oxy always looked for ways to enhance the life support system--even for crew who didn't breathe oxygen! This is an equal opportunity spaceship, after all. However, her work was constantly being interrupted--after months of her workstation being taken over for \"basic diagnostics\" (so stupid; her system always worked perfectly!) Oxy devised the perfect distraction--with just a little short to the Slipdrive Core, Engineering would be too busy dealing with that to bother her. Too bad it ended up a bigger boom than expected..."
                },
                new Character
                {
                    CharacterId = 5,
                    Name = "Jilshey Chompson",
                    Password = "1962",
                    Role = "Chef",
                    TraitName = "Filet Manglore",
                    TraitDescription = "You automatically dissect aliens that you kill on the ship.",
                    Tips = "You're good at shootin' aliens and get stuff for doing so, so make sure you show up where there's aliens--just don't get outnumbered. When ship voting happens, you're going to have to be a dick to some extraterrestials, so get ready to convince people.",
                    Story = "Chef Chompson has one goal, and one goal alone--to be the best culinarian in the universe. Not world, not galaxy--universe. To do so, she'd need to collect the rarest ingredients from all corners of it, and the best way to do so was to accept a civilian contract position on the Exeter. She didn't care about \"research and development\" or \"upholding the Prime Directive\" or any of that nonsense--only cooking up the perfect Ruhlgarian Beefalo Ribcakes and Sarlacc Scroobcakes. The Slip Drive going out would certainly be a damper on those plans, but at least they were near some delectable looking alien species..."
                },
                new Character
                {
                    CharacterId = 6,
                    Name = "Dr. Ed",
                    Password = "6969",
                    Role = "Chief Veterinarian",
                    TraitName = "Medical Mustang",
                    TraitDescription = "You can remove Injury from one player without teleporting anywhere.",
                    Tips = "Feel free to play it up as much (or as little) as you like. Bonus points if -exactly- one person reports correctly. Pick your favorite person to fuck with. Other than that, hang back and apply horse medicine to whomstever needs it. (Also, you are not required to wear a horse head.)",
                    Story = "He's a horse, of course. Of fucking course. But Dr. Ed couldn't let anyone know his deep, dark secret, not if he wanted to pursue his true dream of being a doctor. A horse doctor. In space. But not a doctor for horses, just a doctor that is also a horse. It gets a little weird if you think too hard about semantics. Still, after acquiring a high-end holographic device, Ed was able to hide himself convincingly enough to graduate at the top of his class at OK Corral Cardiovascular Health Centre of Learning, and snag a job on the Exeter. As long as nobody finds out about him, things should be smooth sailing..."
                },
                new Character
                {
                    CharacterId = 7,
                    Name = "Wrench Thornbody",
                    Password = "9431",
                    Role = "4th Chief Engineer",
                    TraitName = "Teleporter Override",
                    TraitDescription = "You never get kicked out of a room that reaches maximum capacity if you're repairing a station.",
                    Tips = "You still count against maximum Life Support capacity--you just won't get the boot from a room if it's too full while you're fixin' stuff. Try and focus on priority repairs, and lock down troublemaking players (or, you know, just for funsies).",
                    Story = "This is Wrench's god damn ship. No, we're not going to revolutionize the drone system for fun. No, you can't play whiffleball in Engineering. No, we're not going to risk the engine blowing just to power the cryo station carrying Toppensandan colonists to their new destination. Wrench knows that the heart of the Slipdrive rests in his hands--and the only way to keep power to it was to cut the power to the cryo stations, killing the colonists. There was only like 13 of them, anyway, and the lives of the crew were more important... and then the Slipdrive blows, anyway. What a day..."
                },
                new Character
                {
                    CharacterId = 8,
                    Name = "Dr. Snapson",
                    Password = "9374",
                    Role = "Research Director",
                    TraitName = "Weird Science",
                    TraitDescription = "You get to pick what the next Research Project is.",
                    Tips = "You get final say on what the ship researches, but listen to the rest of the crew for their recommendations. Try and keep the Science Lab chugging as hard as you can.",
                    Story = "Dr. Ohe Snapson is a revolutionary in all fields of science--genetics, biology, chemistry, astrophysics,  meta astrophysics, meta-meta astrophysics, the works--and was a natural fit as the Exeter's Research Director. But her thirst for knowledge was left constantly left unquenched due to the captain's tendency to underbudget R&D--when Dr. Snapson discovered that the captain had spent 860,000 Spacebucks on candles while only sending 100 to Science, she decided he was only an obstacle. Fortunately, it's nothing a little modification of Black Velanese Truffles into a deadly gas couldn't fix..."
                },
                new Character
                {
                    CharacterId = 9,
                    Name = "Weltall Stutzer",
                    Password = "7777",
                    Role = "Dandy",
                    TraitName = "Sidekick",
                    TraitDescription = "Your Betelguesian buddy sometimes texts you info on aliens in the galaxy... when he feels like it.",
                    Tips = "Keep an eye on where aliens are showing up and mow 'em down, even (-especially-) if you think a bunch of people are already going to the same room. Otherwise, just hang back and live with the flow, baby.",
                    Story = "Weltall joined the Exeter crew after his old ship got blown up. Nobody's really sure what he does--he's not a particularly good shot, but he still manages to successfully murder Mangalorians (seemingly by accident) whenever they show up. Things just seem to go his way, most of the time, even if he ends up making things worse for everyone else in the process. Still, being shoved off into the far reaches of space leaves you far, far, away from the one thing that matters--booty. The whole galaxy will know Weltall's wrath!"
                },
                new Character
                {
                    CharacterId = 10,
                    Name = "Gristle Bonerum",
                    Password = "2001",
                    Role = "ISAAC Representative",
                    TraitName = "Manual Override",
                    TraitDescription = "Once per game, the room you visit has no maximum capacity due to Life Support.",
                    Tips = "Your ability is super powerful, but you only get it once. Try and keep your targets alive the best you can.",
                    Story = "Interstellar Science and Astronomy Committee member Gristle Bonerum was assigned to the Exeter as part of a regulations inspection--only scheduled to be on the ship for a week, it's taken a month to complete his reports due to everything going fucking -wrong-. Finally, when everything was said and done, Gristle's eyes glazed over when he noticed the individual crew reports hadn't been completed. Well... there couldn't be any reports if the crew manifest was damaged, right? Just a little drop in the Recycle Bin..."
                },
                new Character
                {
                    CharacterId = 11,
                    Name = "Chuck Splinthair",
                    Password = "8008",
                    Role = "Tactical Officer",
                    TraitName = "Big Bada Boom",
                    TraitDescription = "Your missiles deal an extra damage to enemy ships.",
                    Tips = "You're great at blowing stuff up, so hang out and fire at enemy ships. The Diplomat (Arianna) will be working with you closely (but remember, her end goals might not align with yours!)",
                    Story = "CHUCK WANTS FOOD. REAL FOOD. NOT SPACE FOOD. REPLICATOR MAKE BAD FOOD. TIRED OF PROTEIN PASTE. CHUCK REQUIRES MEAT. REAL MEAT. CHUCK SMASH REPLICATOR. ... he's not usually that bad, but sucking down tube after tube of space goop and freeze-dried \"ice cream\" only gets you so far, and the chef's \"cooking\" definitely wasn't up to snuff. Maybe this little off-course journey would get some tasty eats... and if not, maybe there's a market for clone-burgers, right?"
                },
                new Character
                {
                    CharacterId = 12,
                    Name = "Carmen Floordeck",
                    Password = "1110",
                    Role = "Security Officer",
                    TraitName = "Unstoppable",
                    TraitDescription = "Aliens can never injure you (but other game effects still can).",
                    Tips = "You're super good at shootin' up aliens but also are in a good position to sniff out crew shenanigans. The easiest way to off someone is to have a bunch of aliens in a room, promise you're going to go protect it so it's totally safe to go there, and then don't.",
                    Story = "Carmen only caught flak for being a woman in security until her second day of training, where she threw a Vogon through a triple-reinforced window after snapping three of his mouth-tendrils clean off with her bare damn hands. Carmen thrives on chaos around her, and the Exeter seemed like a great place for a person of action--until it ended up being the most dull thing ever imaginable. Fortunately, with that fancy cloning system they have, she can have a little fun at the expense of the crew."
                },
                new Character
                {
                    CharacterId = 13,
                    Name = "B.E.E.F.",
                    Password = "0712",
                    Role = "Android",
                    TraitName = "Doong-Type Body",
                    TraitDescription = "You are never negatively affected by Space Anomolies.",
                    Tips = "You can pretty much cruise through this one; your trait lets you ignore some of the bad shit happening. Use your time to figure out who sabotaged the engine!",
                    Story = "Being an android sucks. People always expect your positronic brain to not comprehend human emotion. That's because they're dumb meatbags full of flesh and organs, not superior artificial lifeforms like yourself. Still, they have some sort of curious nature to you, so keeping them alive is entertaining, at least--doubly so when they flip out about their navigation systems going offline after you uploaded a virus directly into its processing unit. That'll show them! ... wait, shit, you're on the ship, too."
                },
                new Character
                {
                    CharacterId = 14,
                    Name = "Ol' Rusty",
                    Password = "3644",
                    Role = "Mawg",
                    TraitName = "Alien Morphology",
                    TraitDescription = "You don't count against a room's maximum capacity, but still get kicked out if it overloads.",
                    Tips = "You can tag along with just about anybody without worrying about overloading a room. You're your own best friend, but also everyone else's, too!",
                    Story = "Ol' Rusty never thought himself as bein' a great boy, or an excellent boy. Maybe a good boy. But got'dang if them scanners ain't makin a helluva racket. Day in, day out, high pitched squealin'--and Engeineering wasn't gonna do a plum thing 'bout it, since they couldn't hear it. It's unfortunate that Ol' Rusty picked right before the ship went haywire to jam up the signal to stop the noise. Maybe he's just an OK boy."
                },
                new Character
                {
                    CharacterId = 15,
                    Name = "Guy Trustworthy",
                    Password = "4019",
                    Role = "Syndicate Agent",
                    TraitName = "Cloaking Device",
                    TraitDescription = "You never show up on room reports (but still show on Crew or Security reports). Your fake ID shows as \"Space Janitor\" and you have no Crew Record on file.",
                    Tips = "Be careful where you pick your fights--you want to be able to protect your crew from dying, but also don't want to be in a room where someone carks it. Rally support from your crew with Weapons training to help you defend rooms.",
                    Story = "Guy has been so deep undercover on the Exeter he's forgotten his original name; of course, the Syndicate deprogramming course would take care of that for him! From his guise as an innocent Space Janitor, Guy was able to funnel all sorts of Nanotrasen secrets back to the Syndicate--including a report explaining the Syndicate deprogramming course, which involves being shot repeatedly and then spaced. ... fuck them, they never paid him enough anyway. His colors turned blue--he'd get this ship and its crew home or die trying."
                },
                new Character
                {
                    CharacterId = 16,
                    Name = "Weskira LaWorf",
                    Password = "1976",
                    Role = "Author Self Insert",
                    TraitName = "Frail Nerd",
                    TraitDescription = "In addition to your listed skills, you also have the Engineering skill. You cannot fight aliens directly, and are guaranteed to get injured if one's in your room.",
                    Tips = "You have three skills so you are a great master-of-all-trades... unless that trade is fighting. Stay the hell away from any room that contains aliens unless you're absolutely certain you can be protected.",
                    Story = "Weskira--one half human, one half Malbortian, and one half cyborg (but he got all the cybernetic implants removed after his encounter with Future Jesus on Rammsteinn IV as he would have been too powerful) --or so he says. Weskira has secretly always thought himself special, but isn't really sure why; perhaps a greater force was guiding him. He would have to find out! Surely nobody would notice if he jacked the samples out of the research lab to run his own experiments--but he'd have to take out the replicators there in order to get to them. Maybe he can find his destiny through the power of science! ... as long as he doesn't get shot."
                },
                new Character {CharacterId = 17, Name = "Ahsat Ray", Password = "3844", Role = "Security Guard"},
                new Character {CharacterId = 18, Name = "Dr. Kleiner", Password = "5737", Role = "Lab Assistant"},
                new Character {CharacterId = 19, Name = "Redd Shirt", Password = "5283", Role = "Junior Officer"},
                new Character {CharacterId = 20, Name = "Fix McRunfast", Password = "3425", Role = "Engineer"},
                new Character {CharacterId = 21, Name = "Bobbi Johnson", Password = "8665", Role = "Helmsman"}
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
                new CharacterSkill {CharacterSkillId = 35, CharacterId = 15, SkillId = 6},
                new CharacterSkill {CharacterSkillId = 36, CharacterId = 21, SkillId = 3}
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

                new CharacterObjective { CharacterObjectiveId = 26, CharacterId = 6, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 27, CharacterId = 6, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 28, CharacterId = 6, ObjectiveId = 9},
                new CharacterObjective { CharacterObjectiveId = 29, CharacterId = 6, ObjectiveId = 16},
                new CharacterObjective { CharacterObjectiveId = 30, CharacterId = 6, ObjectiveId = 17},

                new CharacterObjective { CharacterObjectiveId = 31, CharacterId = 7, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 32, CharacterId = 7, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 33, CharacterId = 7, ObjectiveId = 18},
                new CharacterObjective { CharacterObjectiveId = 34, CharacterId = 7, ObjectiveId = 19},
                new CharacterObjective { CharacterObjectiveId = 35, CharacterId = 7, ObjectiveId = 20},

                new CharacterObjective { CharacterObjectiveId = 36, CharacterId = 8, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 37, CharacterId = 8, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 38, CharacterId = 8, ObjectiveId = 21},
                new CharacterObjective { CharacterObjectiveId = 39, CharacterId = 8, ObjectiveId = 22},
                new CharacterObjective { CharacterObjectiveId = 40, CharacterId = 8, ObjectiveId = 23},

                new CharacterObjective { CharacterObjectiveId = 41, CharacterId = 9, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 42, CharacterId = 9, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 43, CharacterId = 9, ObjectiveId = 21},
                new CharacterObjective { CharacterObjectiveId = 44, CharacterId = 9, ObjectiveId = 24},
                new CharacterObjective { CharacterObjectiveId = 45, CharacterId = 9, ObjectiveId = 25},

                new CharacterObjective { CharacterObjectiveId = 46, CharacterId = 10, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 47, CharacterId = 10, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 48, CharacterId = 10, ObjectiveId = 18},
                new CharacterObjective { CharacterObjectiveId = 49, CharacterId = 10, ObjectiveId = 30},
                new CharacterObjective { CharacterObjectiveId = 50, CharacterId = 10, ObjectiveId = 27},

                new CharacterObjective { CharacterObjectiveId = 51, CharacterId = 11, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 52, CharacterId = 11, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 53, CharacterId = 11, ObjectiveId = 6},

                new CharacterObjective { CharacterObjectiveId = 54, CharacterId = 12, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 55, CharacterId = 12, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 56, CharacterId = 12, ObjectiveId = 21},

                new CharacterObjective { CharacterObjectiveId = 57, CharacterId = 13, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 58, CharacterId = 13, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 59, CharacterId = 13, ObjectiveId = 9},

                new CharacterObjective { CharacterObjectiveId = 60, CharacterId = 14, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 61, CharacterId = 14, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 62, CharacterId = 14, ObjectiveId = 3},
                new CharacterObjective { CharacterObjectiveId = 63, CharacterId = 14, ObjectiveId = 28},
                new CharacterObjective { CharacterObjectiveId = 64, CharacterId = 14, ObjectiveId = 29},

                new CharacterObjective { CharacterObjectiveId = 65, CharacterId = 15, ObjectiveId = 1},
                new CharacterObjective { CharacterObjectiveId = 66, CharacterId = 15, ObjectiveId = 2},
                new CharacterObjective { CharacterObjectiveId = 67, CharacterId = 15, ObjectiveId = 18},
            };
            db.CharacterObjectives.AddRange(characterObjectives);
            db.SaveChanges();

            var attributes = new[]
            {
                new Attribute { AttributeId = 1, Name = "Helm", Abbreviated = "Helm", SkillId = 3, LocationId = 1, VariableType = VariableType.None},
                new Attribute { AttributeId = 2, Name = "Battle Stations", Abbreviated = "Battle Stations", SkillId = 6, LocationId = 1, VariableType = VariableType.MultipleChoice},
                new Attribute { AttributeId = 3, Name = "Point Defense Systems", Abbreviated = "Pt Def Systems", SkillId = 6, LocationId = 1, VariableType = VariableType.MultipleChoice},
                new Attribute { AttributeId = 4, Name = "Short Range Scanners", Abbreviated = "Short Range Scanners", SkillId = 4, LocationId = 2, VariableType = VariableType.None},
                new Attribute { AttributeId = 5, Name = "Long Range Scanners", Abbreviated = "Long Range Scanners", SkillId = 4, LocationId = 2, VariableType = VariableType.MultipleChoice},
                new Attribute { AttributeId = 6, Name = "Requisition Line", Abbreviated = "Requisition Line", SkillId = 1, LocationId = 2, VariableType = VariableType.None},
                new Attribute { AttributeId = 7, Name = "Mech Bay", Abbreviated = "Mech Bay", SkillId = 2, LocationId = 3, VariableType = VariableType.None},
                new Attribute { AttributeId = 8, Name = "Repair Drone Control", Abbreviated = "Repair Drone Control", SkillId = 3, LocationId = 3, VariableType = VariableType.Drones},
                new Attribute { AttributeId = 9, Name = "Atmospherics", Abbreviated = "Atmospherics", SkillId = 2, LocationId = 3, VariableType = VariableType.Locations},
                new Attribute { AttributeId = 10, Name = "Slip Drive", Abbreviated = "Slip Drive", LocationId = 3, VariableType = VariableType.None},
                new Attribute { AttributeId = 11, Name = "Auto Doc", Abbreviated = "Auto Doc", LocationId = 4, VariableType = VariableType.None},
                new Attribute { AttributeId = 12, Name = "Crew Records", Abbreviated = "Crew Records", SkillId = 1, LocationId = 4, VariableType = VariableType.Crew},
                new Attribute { AttributeId = 13, Name = "Cloning Pods", Abbreviated = "Cloning Pods", LocationId = 4, VariableType = VariableType.None},
                new Attribute { AttributeId = 14, Name = "Research Lab", Abbreviated = "Research Lab", SkillId = 4, LocationId = 5, VariableType = VariableType.None},
                new Attribute { AttributeId = 15, Name = "Xenobiology", Abbreviated = "Xenobiology", SkillId = 4, LocationId = 5, VariableType = VariableType.None},
                new Attribute { AttributeId = 16, Name = "Robotics", Abbreviated = "Robotics", SkillId = 2, LocationId = 5, VariableType = VariableType.None},
                new Attribute { AttributeId = 17, Name = "Lockdown Station", Abbreviated = "Lockdown Station", SkillId = 1, LocationId = 6, VariableType = VariableType.Crew},
                new Attribute { AttributeId = 18, Name = "Security Report", Abbreviated = "Security Report", SkillId = 1, LocationId = 6, VariableType = VariableType.Crew},
                new Attribute { AttributeId = 19, Name = "Security Drone Control", Abbreviated = "Security Drone Control", SkillId = 3, LocationId = 6, VariableType = VariableType.Drones},
                new Attribute { AttributeId = 20, Name = "Cargo Bay", Abbreviated = "Cargo Bay", LocationId = 7, VariableType = VariableType.None},
                new Attribute { AttributeId = 21, Name = "Armory", Abbreviated = "Armory", LocationId = 7, VariableType = VariableType.None},
                new Attribute { AttributeId = 22, Name = "Mining Drone Control", Abbreviated = "Mining Drone Control", SkillId = 3, LocationId = 7, VariableType = VariableType.Drones},
                new Attribute { AttributeId = 23, Name = "Defend Self", Abbreviated = "Defend Self", VariableType = VariableType.None},
                new Attribute { AttributeId = 24, Name = "Fight Aliens", Abbreviated = "Fight Aliens", SkillId = 6, VariableType = VariableType.None},
                new Attribute { AttributeId = 26, Name = "Repair Station", Abbreviated = "Repair Station", VariableType = VariableType.Stations},
            };
            db.Attributes.AddRange(attributes);
            db.SaveChanges();

            var drones = new[]
            {
                new Drone {DroneId = 1, Name = "SecurityBot \"Beepsky\"", LocationId = 6, Use = "Defends areas against aliens.", Description = "Automatically kills an alien in their room. Destroyed by aliens if there are no players in the room."},
                new Drone {DroneId = 2, Name = "RepairBot", LocationId = 3, Use = "Repairs broken substations.", Description = "Automatically repairs the most damaged substation in their room by 1. Destroyed by aliens if there are no players in the room. Cannot repair the Slip Drive."},
                new Drone {DroneId = 3, Name = "MineBot", LocationId = 7, Use = "Dispatches to an Object In Space in the current sector and mines it.", Description = "Once dispatched, comes back at the end of next turn with minerals (regardless of ship position). Destroyed by alien ships if there are any in the sector."}
            };
            db.Drones.AddRange(drones);
            db.SaveChanges();

            var minerals = new[]
            {
                new Mineral {MineralId = 1, Action = "Atmoline", Acquired = "Mining", Cost = 1, Use = "Increases Life Support at Atmospherics."},
                new Mineral {MineralId = 2, Action = "Xenonite", Acquired = "Xenobiology", Cost = 1, Use = "Good for research. Two can be used as a wildcard in any research."},
                new Mineral {MineralId = 3, Action = "Dolomite", Acquired = "Mining", Cost = 1, Use = "Used in upgrades."},
                new Mineral {MineralId = 4, Action = "Gold", Acquired = "", Cost = 3, Use = "Worth a lot of Space Bucks."},
                new Mineral {MineralId = 5, Action = "Dongmonium", Acquired = "Mining", Cost = 1, Use = "Used in upgrades."},
                new Mineral {MineralId = 6, Action = "Cummingtonite", Acquired = "Mining", Cost = 1, Use = "Used in upgrades."},
                new Mineral {MineralId = 7, Action = "Brosephite", Acquired = "Mining", Cost = 1, Use = "Used in upgrades."},
                new Mineral {MineralId = 8, Action = "Bepis", Acquired = "Mining", Cost = 1, Use = "Used in upgrades."}
            };
            db.Minerals.AddRange(minerals);
            db.SaveChanges();
        }
    }
}
