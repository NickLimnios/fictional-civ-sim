using fcs.api.Models;
using Microsoft.EntityFrameworkCore;

namespace fcs.api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Civilization> Civilizations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Civilization>().HasKey(c => c.Id);
            modelBuilder.Entity<Resource>().HasKey(r => r.Id);
            modelBuilder.Entity<Event>().HasKey(e => e.Id);

            // Auto - increment IDs
            modelBuilder.Entity<Civilization>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Resource>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Event>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // Relationships
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Civilization)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CivilizationId);

            modelBuilder.Entity<Event>()
               .HasOne(e => e.Civilization)
               .WithMany(c => c.Events)
               .HasForeignKey(e => e.CivilizationId);

            // Seed Data
            modelBuilder.Entity<Civilization>()
                .HasData(
                    new Civilization { Id = 1, Name = "Atlantis", Population = 250 },
                    new Civilization { Id = 2, Name = "Babylon", Population = 150 }
                    );

            modelBuilder.Entity<Resource>()
                .HasData(
                    new Resource { Id = 1, CivilizationId = 1, Name = "Wood", Quantity = 200 },
                    new Resource { Id = 2, CivilizationId = 1, Name = "Minerals", Quantity = 100 },
                    new Resource { Id = 3, CivilizationId = 1, Name = "Food", Quantity = 800 },
                    new Resource { Id = 4, CivilizationId = 2, Name = "Wood", Quantity = 100 },
                    new Resource { Id = 5, CivilizationId = 2, Name = "Food", Quantity = 500 }
                    );


            modelBuilder.Entity<Event>()
                .HasData(
                    new Event { Id = 1, CivilizationId = 1, Year = 0, Description = "Atlantis founded." },
                    new Event { Id = 2, CivilizationId = 2, Year = 0, Description = "Babylon rose to power." }
                    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
