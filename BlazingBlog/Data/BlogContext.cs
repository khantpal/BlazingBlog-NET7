﻿using Microsoft.EntityFrameworkCore;

namespace BlazingBlog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Email = "palkhant@outlook.com",
                        FirstName = "Pal",
                        LastName = "Khant",
                        Salt = "dshfksdhfk",
                        Hash = "dfhkhsdskdfffgfjgfjgkdfhjgkdf/="
                    }
                );
        }
    }
}
