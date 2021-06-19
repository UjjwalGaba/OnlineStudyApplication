using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStudyApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStudyApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // declare all the models so the db can work with them and so can the rest of our app


        public DbSet<Course> Courses { get; set; }

        public DbSet<Study> Studies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
