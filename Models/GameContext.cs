using Microsoft.EntityFrameworkCore;

namespace LCARS.Models
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Teleport> Teleports { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<CharacterObjective> CharacterObjectives { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Mineral> Minerals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}