using System.Data.Entity;
using Kurs_DataLayer.Entities;

namespace Kurs_DataLayer.EFContext
{
    public class EntityContext:DbContext
    {
        public EntityContext(string name) : base(name)
        {
            /* The SetInitializer() method takes an instance of database initializer class and sets 
            it as a database initializer for the current application domain. When you set a database initializer, 
            it won't be called immediately. It will be called when the context  is used for the first time*/
            Database.SetInitializer(new DataBaseInitialzer());
            this.Database.Initialize(true);
            /* At times you may want to use an existing database with Code First. 
            In such cases you may not want to execute any initialization logic at all. 
            You can suppress the database initialization process altogether by passing null to SetInitializer() method.
            example: Database.SetInitializer<BlogContext>(null);*/
        }
        // A DbSet represents the collection of all entities in the context, or that can
        //be queried from the database, of a given type.DbSet objects are created from
        //a DbContext using the DbContext.Set method.
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Route>()
                        .HasRequired(e => e.CityArr)
                        .WithMany(t => t.RoutesArr)
                        .HasForeignKey(e => e.CityArrId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
            .HasRequired(e => e.Trip)
            .WithMany(t => t.Orders)
            .HasForeignKey(e => e.TripId)
            .WillCascadeOnDelete(false);

        }
    
    }
}
