using System;
using Microsoft.EntityFrameworkCore;

namespace Project4_1.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    categoryID = "1",
                    name = "Work"
                },
                new Category
                {
                    categoryID = "2",
                    name = "Family"
                },
                new Category
                {
                    categoryID = "3",
                    name = "Friend"
                },
                new Category
                {
                    categoryID = "4",
                    name = "Personal"
                },
                new Category
                {
                    categoryID = "5",
                    name = "Other"
                }
                );

            modelBuilder.Entity<Contact>().HasData(
                    new Contact
                    {
                        ID = 1,
                        firstName = "Mark",
                        lastName = "Smith",
                        phone = "440-505-3513",
                        email = "mark.smith@yahoo.com",
                        categoryID = "3",
                        CreatedDate = new DateTime()
                    },
                    new Contact
                    {
                        ID = 2,
                        firstName = "Linda",
                        lastName = "Jones",
                        phone = "638-424-2940",
                        email = "lj1989@gmail.com",
                        categoryID = "5",
                        CreatedDate = new DateTime()
                    },
                    new Contact
                    {
                        ID = 3,
                        firstName = "Bailey",
                        lastName = "Stewart",
                        phone = "034-514-5462",
                        email = "bailey.stewart@aol.com",
                        categoryID = "1",
                        organization = "Apple",
                        CreatedDate = new DateTime()
                    }
                    ) ;        
        }
    }
}
