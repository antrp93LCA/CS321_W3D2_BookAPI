﻿using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CS321_W3D2_BookAPI.Data
{
    public class BookContext : DbContext
    {
        //implement DbSet<Entity> properties for all table sets in database
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        // This method runs once when the DbContext is first used.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use optionsBuilder to configure a Sqlite db
            optionsBuilder.UseSqlite("Data Source=books.db");
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configure some seed data in the authors table
            modelBuilder.Entity<Author>().HasData(
               new Author { Id = 1, FirstName = "John", LastName = "Steinbeck", BirthDate = new DateTime(1902, 2, 27) },
               new Author { Id = 2, FirstName = "Stephen", LastName = "King", BirthDate = new DateTime(1947, 9, 21) }
            );

            //seed data for publishers table
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Viking Press", CountryOfOrigin = "USA", FoundedYear = 1925, HeadQuartersLocation = "NY, NY" },
                new Publisher { Id = 2, Name = "Doubleday", CountryOfOrigin = "USA", FoundedYear = 1897, HeadQuartersLocation = "NY, NY" }
            );

            //configure some seed data in the books table
            modelBuilder.Entity<Book>().HasData(
               new Book { Id = 1, Title = "The Grapes of Wrath", AuthorId = 1, PublisherId = 1 },
               new Book { Id = 2, Title = "Cannery Row", AuthorId = 1, PublisherId = 1 },
               new Book { Id = 3, Title = "The Shining", AuthorId = 2, PublisherId = 2 }
            );

        }
    }
}