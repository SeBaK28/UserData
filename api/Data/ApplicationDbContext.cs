using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.UserData>()
            .HasMany(e => e.PlaceOfBirths)
            .WithOne(e => e.userData)
            .HasForeignKey(e => e.UserDataId)
            .IsRequired(false);

            modelBuilder.Entity<Models.UserData>()
            .HasMany(e => e.ResidentialAddresProp)
            .WithOne(e => e.userData)
            .HasForeignKey(e => e.UserDataId)
            .IsRequired(true);

            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }

        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<PlaceOfBirth> PlaceOfBirths { get; set; }
        public DbSet<ResidentialAddres> ResidentialAddress { get; set; }

    }
}