using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TBWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : DbContext
    {
 
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
          this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<CustomerProfile>().
            HasMany(c => c.Agencies).
            WithMany(p => p.CustomerProfiles).
            Map(
                m =>
                {
                    m.MapLeftKey("CustomerProfileId");
                    m.MapRightKey("AgencyId");
                    m.ToTable("AgenciesCustomerProfiles");
                });

            modelBuilder.Entity<Product>().
    HasMany(c => c.Agencies).
    WithMany(p => p.Products).
    Map(
        m =>
        {
            m.MapLeftKey("ProducId");
            m.MapRightKey("AgencyId");
            m.ToTable("AgenciesProducts");
        });

            modelBuilder.Entity<PaymentMethod>().
    HasMany(c => c.Agencies).
    WithMany(p => p.PaymentMethods).
    Map(
        m =>
        {
            m.MapLeftKey("PaymentMethodId");
            m.MapRightKey("AgencyId");
            m.ToTable("AgenciesPaymentMethods");
        });


        }

        public System.Data.Entity.DbSet<TBWeb.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Trip> Trips { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Bid> Bids { get; set; }

        public System.Data.Entity.DbSet<TBWeb.Models.Agency> Agencies { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.AgencyUser> AgenciesUsers { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Message> Messages { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.News> News { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Destination> Destinations { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Continent> Continents { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Country> Countries { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.Region> Regions { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.State> States { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.City> Cities { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.CustomerProfile> CustomerProfiles { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.PaymentMethod> PaymentMethods { get; set; }
        public System.Data.Entity.DbSet<TBWeb.Models.MemberCategory> MemberCategories { get; set; }

    }

 


}