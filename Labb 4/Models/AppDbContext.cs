using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<BorrowedBook> BorrowedBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new Book { Id = 1, Title = "Project Hail Mary", Author = "Andy Weir", BookId = 10000, BookRating = 8.0f });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 2, Title = "Atomic Habits", Author = "James Clear", BookId = 10001, BookRating = 7.5f });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 3, Title = "The Secret History", Author = "Donna Tartt", BookId = 10002, BookRating = 7.0f });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 4, Title = "The Blade Itself", Author = "Joe Abercrombie", BookId = 10003, BookRating = 8.35f });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 5, Title = "Fingerprints of the Gods", Author = "Graham Hancock", BookId = 10004, BookRating = 9.5f });


            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, FirstName = "Adam", LastName = "Adamsson", Adress = "Hejsanhoppsanstigen 13", PhoneNumber = "0709-123123" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, FirstName = "Bertil", LastName = "Bertilsson", Adress = "Bamsegatan 37"});
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 3, FirstName = "Ceasar", LastName = "Ceasarsson", Adress = "Ajvarvägen 1"});
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 4, FirstName = "David", LastName = "Davidsson", Adress = "Väg 1" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 5, FirstName = "Erik", LastName = "Eriksson", Adress = "Skogstråket" });

            modelBuilder.Entity<BorrowedBook>().HasData(new BorrowedBook { Id = 1, BookId = 1, CustomerId = 1, ReturnTime = DateTime.Now.AddMonths(1), BeenReturned = false });
            modelBuilder.Entity<BorrowedBook>().HasData(new BorrowedBook { Id = 2, BookId = 2, CustomerId = 1, ReturnTime = DateTime.Now.AddMonths(1), BeenReturned = false });
            modelBuilder.Entity<BorrowedBook>().HasData(new BorrowedBook { Id = 3, BookId = 3, CustomerId = 1, ReturnTime = DateTime.Now.AddMonths(1), BeenReturned = false });
        }


    }
}
