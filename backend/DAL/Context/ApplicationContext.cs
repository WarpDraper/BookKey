using AuthDomain;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{


    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.FavoriteBooks)
                .WithMany(b => b.FavoritedByUsers)
                .UsingEntity(j => j.ToTable("UserFavoriteBooks"));

            builder.Entity<Book>()
                .Property(b => b.Rating)
                .HasDefaultValue(0);
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
    }
}
