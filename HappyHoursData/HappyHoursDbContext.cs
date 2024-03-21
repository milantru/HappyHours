using HappyHoursData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHoursData
{
    public class HappyHoursDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessBranch> BusinessBranches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                            .AddUserSecrets<HappyHoursDbContext>()
                            .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<BusinessBranch>()
		        .HasMany(bb => bb.Customers)
		        .WithMany(c => c.FavouriteBranches)
		        .UsingEntity(
			        l => l.HasOne(typeof(Customer)).WithMany().OnDelete(DeleteBehavior.Restrict),
			        r => r.HasOne(typeof(BusinessBranch)).WithMany().OnDelete(DeleteBehavior.Restrict));
		}
	}
}
