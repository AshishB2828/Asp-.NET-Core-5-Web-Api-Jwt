using ListingApi.Config.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Data
{
    public class DatabaseContext:IdentityDbContext<ApiUser>
    {


        public DatabaseContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration()); //alternate way for seeding data

            //seeding data  
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "CNTest-1",
                    ShortName = "CSTest-1"
                },
                new Country
                {
                    Id = 2,
                    Name = "CNTest-2",
                    ShortName = "CSTest-2"
                },
                new Country
                {
                    Id = 3,
                    Name = "CNTest-3",
                    ShortName = "CSTest-3"
                }
            );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "HNTest-1",
                    Address = "HATest-1",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "HNTest-2",
                    Address = "HATest-1",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "HNTest-3",
                    Address = "HATest-1",
                    CountryId = 2,
                    Rating = 4
                }
            );
        }
     }
}
