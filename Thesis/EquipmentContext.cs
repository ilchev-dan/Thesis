using Microsoft.EntityFrameworkCore;

namespace Thesis
{
    /// <summary>
    /// Sets the context for working with the DB
    /// </summary>
    public class EquipmentContext : DbContext
    {
        //DbSet represents a set of objects that are stored in a DB
        public DbSet<Event> Events { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<WorkplaceForEvent> WorkplaceForEvents { get; set; }

        //Setting the connection parameters
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Select SQLite and set the name
            optionsBuilder.UseSqlite("Data Source=equipment.db");
            //We use lazy-loading in the DB, so child entities are automatically loaded when accessing from the parent entity
            optionsBuilder.UseLazyLoadingProxies();
            //Calling the configuration
            base.OnConfiguring(optionsBuilder);
        }

        //Setting the parameters for creating tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Applying the configuration created in ModelConfig.cs
            modelBuilder.ApplyConfiguration(new EquipmentConfig());
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new WorkplaceConfig());
            modelBuilder.ApplyConfiguration(new WorkplaceForEventConfig());
        }
    }
}
