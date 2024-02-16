using Microsoft.EntityFrameworkCore;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Infrastructure.Persistence
{
    public class WebAppMVCDbContext : DbContext
    {
        public WebAppMVCDbContext(DbContextOptions<WebAppMVCDbContext> options) : base(options) { }
        public DbSet<FootballTeam> FootballTeams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<FootballTeam>()
                .Property(f => f.Name)
                .IsRequired();

            modelBuilder.Entity<Match>()
                .Property(m => m.NameFirstTeam)
                .IsRequired();

            modelBuilder.Entity<Match>()
                .Property(m => m.NameSecondTeam)
                .IsRequired();

            modelBuilder.Entity<Queue>()
                .Property(q => q.Description)
                .IsRequired();

            modelBuilder.Entity<League>()
                .Property(l => l.Name)
                .IsRequired();
        }
    }
}
