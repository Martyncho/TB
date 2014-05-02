namespace TBWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TBWeb.Models;

    public sealed class AppDbContextSeedInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>
    {
    }

    public sealed class Configuration : DbMigrationsConfiguration<TBWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TBWeb.Models.ApplicationDbContext context)
        {
            //var c1 = new Customer { Mail = "legnani@gmail.com", Name = "Martin Legnani", PostalCode = "1256" };
            //context.Customers.AddOrUpdate(c1);
            //var c2 = new Customer { Mail = "santiagolegnani@gmail.com", Name = "Santiago Legnani", PostalCode = "1256" };
            //context.Customers.AddOrUpdate(c2);
            //var c3 = new Customer { Mail = "eduardogoldenhorn@gmail.com", Name = "Eduardo Gondelhorn", PostalCode = "1256" };
            //context.Customers.AddOrUpdate(c3);
            //context.SaveChanges();


            //var t1 = new Trip { Category = "Paquetes", Destination = "Miami", IsFinished = false, Description = "Salida Noviembre 2014, 7 Noches, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, ", Customer = c1, PostDate = DateTime.Now, DurationDays = 7 };
            //context.Trips.AddOrUpdate(t1);
            //var t2 = new Trip { Category = "Aereos", Destination = "Disney", IsFinished = false, Description = "Salida Noviembre 2014, 8 Noches, Incluye AereoIncluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, ", Customer = c1, PostDate = DateTime.Now, DurationDays = 7 };
            //context.Trips.AddOrUpdate(t2);
            //var t3 = new Trip { Category = "Paquetes", Destination = "Miami", IsFinished = false, Description = "Salida Diciembre 2014, 7 Noches, Incluye AereoIncluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, Incluye Aereo Hotel 5 Estrellas, Cancun, ", Customer = c2, PostDate = DateTime.Now, DurationDays = 7 };
            //context.Trips.AddOrUpdate(t3);
            //var t4 = new Trip { Category = "Paquetes", Destination = "Miami - Disney", IsFinished = false, Description = "Salida Octubre 2014, 7 Noches, Incluye Aereo", Customer = c2, PostDate = DateTime.Now, DurationDays = 7 };
            //context.Trips.AddOrUpdate(t4);
            //var t5 = new Trip { Category = "Paquetes", Destination = "Miami", IsFinished = false, Description = "Salida Noviembre 2014, 7 Noches, Incluye Aereo", Customer = c3, PostDate = DateTime.Now, DurationDays = 7 };
            //context.Trips.AddOrUpdate(t5);
            //context.SaveChanges();

            //var b1 = new Bid { AgencyId = 1000, Price = 5000, Destino = "Miami", Viewed = false, Description = "Salida Noviembre 2014, 7 Noches, Incluye Aereo", Trip = t1, TripId = 1, DurationDays = 7, PostDate = DateTime.Now, SaveForLater = false, Selected = false, BidTripNumber = 1 };
            //context.Bids.AddOrUpdate(b1);
            //var b2 = new Bid { AgencyId = 1001, Price = 5000, Destino = "Disney", Viewed = false, Description = "Salida Noviembre 2014, 8 Noches, Incluye Aereo", Trip = t1, TripId = 1, DurationDays = 7, PostDate = DateTime.Now, SaveForLater = false, Selected = false, BidTripNumber = 1 };
            //context.Bids.AddOrUpdate(b2);
            //var b3 = new Bid { AgencyId = 1002, Price = 8000, Destino = "Miami", Viewed = false, Description = "Salida Diciembre 2014, 7 Noches, Incluye Aereo", Trip = t2, TripId = 2, DurationDays = 7, PostDate = DateTime.Now, SaveForLater = false, Selected = false, BidTripNumber = 1 };
            //context.Bids.AddOrUpdate(b3);
            //var b4 = new Bid { AgencyId = 1003, Price = 7000, Destino = "Miami - Disney", Viewed = false, Description = "Salida Octubre 2014, 7 Noches, Incluye Aereo", Trip = t2, TripId = 2, DurationDays = 7, PostDate = DateTime.Now, SaveForLater = false, Selected = false, BidTripNumber = 1 };
            //context.Bids.AddOrUpdate(b4);
            //var b5 = new Bid { AgencyId = 1004, Price = 6000, Destino = "Miami", Viewed = false, Description = "Salida Noviembre 2014, 7 Noches, Incluye Aereo", Trip = t3, TripId = 3, DurationDays = 7, PostDate = DateTime.Now, SaveForLater = false, Selected = false, BidTripNumber = 1 };
            //context.Bids.AddOrUpdate(b5);
            //context.SaveChanges();
        }
        //protected override void Seed(TBWeb.Models.ApplicationDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
//        }
    }
}
