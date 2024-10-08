using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_03_10
{
    internal class AdditionalTask1
    {
        static void Main(string[] args)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var books = db.Books.ToList();

                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=PostreSqlDB;Username=postgres;Password=vwrsjqw3712");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice Smith", Email = "alice.smith@example.com", Age = 28 },
                new User { Id = 2, Name = "Bob Johnson", Email = "bob.johnson@example.com", Age = 34 },
                new User { Id = 3, Name = "Charlie Brown", Email = "charlie.brown@example.com", Age = 22 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "To Kill a Mockingbird", Description = "A novel about the serious issues of rape and racial inequality.", Author = "Harper Lee", Year = 1960 },
                new Book { Id = 2, Title = "1984", Description = "A dystopian social science fiction novel and cautionary tale about the future.", Author = "George Orwell", Year = 1949 },
                new Book { Id = 3, Title = "The Great Gatsby", Description = "A novel about the American dream and the roaring twenties.", Author = "F. Scott Fitzgerald", Year = 1925 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
