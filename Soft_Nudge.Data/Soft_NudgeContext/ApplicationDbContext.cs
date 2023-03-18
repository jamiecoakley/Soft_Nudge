using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Soft_Nudge.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft_Nudge.Data.Soft_NudgeContext
{
        public class ApplicationDbContext : IdentityDbContext<AppUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<AppUser> AppUser { get; set; }
            public DbSet<ToDo> ToDos { get; set; }
            public DbSet<Note> Notes { get; set; }
            public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Category>().HasData(
        //        new Category
        //        {
        //            Id = 1,
        //            Name = "Self Care",
        //            OwnerId = null,
        //        },
        //        new Category
        //        {
        //            Id = 2,
        //            Name = "Space Care",
        //            OwnerId = null,
        //        },
        //        new Category
        //        {
        //            Id = 3,
        //            Name = "Hobbies",
        //            OwnerId = null,
        //        },
        //        new Category
        //        {
        //            Id = 4,
        //            Name = "Projects",
        //            OwnerId = null,
        //        }
        //    );
        //}
    }
}
