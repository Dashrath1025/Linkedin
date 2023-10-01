using LinkedIn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Data
{
    public class AppDb:IdentityDbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<JobCategory> jobCategories { get; set; }

        public DbSet<JobOffer> jobOffers { get; set; }

        public DbSet<JobSeeker> jobSeekers { get; set; }

        public DbSet<JobView> jobViews { get; set; }



    }
}
