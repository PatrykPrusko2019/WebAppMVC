using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Infrastructure.Persistence
{
    public class WebAppMVCDbContext : IdentityDbContext
    {
        public WebAppMVCDbContext(DbContextOptions<WebAppMVCDbContext> options) : base(options) { }
        public DbSet<FootballTeam> FootballTeams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<FavouriteTeamsUser> FavouriteTeamsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
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
