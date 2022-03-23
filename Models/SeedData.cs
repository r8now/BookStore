using BookStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
            {
                if (context.Books.Any())    // Check if database contains any books
                {
                    return;     // Database contains books already
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Web Design with HTML, CSS, JavaScript and Jquery Set",
                        Language = "English",
                        ISBN = "9781118907443",
                        DatePublished = DateTime.Parse("2014-08-15"),
                        Price = 399,
                        Author = "Jon Ducket",
                        ImageUrl = "/images/image1.jpg"
                    },

                    new Book
                    {
                        Title = "Eloquent Javascript, 3rd Edition",
                        Language = "English",
                        ISBN = "9781593279509",
                        DatePublished = DateTime.Parse("2018-12-04"),
                        Price = 419,
                        Author = "Marijn Haverbeke",
                        ImageUrl = "/images/image2.jpg"
                    },

                    new Book
                    {
                        Title = "Don´t make me think, Revisited",
                        Language = "English",
                        ISBN = "9780321965516",
                        DatePublished = DateTime.Parse("2014-01-09"),
                        Price = 299,
                        Author = "Krug Steve",
                        ImageUrl = "/images/image3.jpg"
                    },

                    new Book
                    {
                        Title = "Databasteknik",
                        Language = "Swedish",
                        ISBN = "9789144069197",
                        DatePublished = DateTime.Parse("2018-04-25"),
                        Price = 519,
                        Author = "Thomas Padron-McCarthy och Tore Risch",
                        ImageUrl = "/images/image4.jpg"
                    },

                    new Book
                    {
                        Title = "Agil projektledning",
                        Language = "Swedish",
                        ISBN = "9789152358368",
                        DatePublished = DateTime.Parse("2020-01-08"),
                        Price = 508,
                        Author = "Tomas Gustavsson",
                        ImageUrl = "/images/image5.jpg"
                    },

                    new Book
                    {
                        Title = "C# 8.0 and .NET Core",
                        Language = "English",
                        ISBN = "9781788478120",
                        DatePublished = DateTime.Parse("2019-01-01"),
                        Price = 384,
                        Author = "Mark J. Price",
                        ImageUrl = "/images/image6.jpg"
                    },

                    new Book
                    {
                        Title = "Entreprenörskap och företagsetablering",
                        Language = "Swedish",
                        ISBN = "9789144021478",
                        DatePublished = DateTime.Parse("2008-12-02"),
                        Price = 536,
                        Author = " Hans Landström, Marie Löwegren",
                        ImageUrl = "/images/image7.jpg"
                    },

                    new Book
                    {
                        Title = "WordPress 5 Complete",
                        Language = "English",
                        ISBN = "9781789532012",
                        DatePublished = DateTime.Parse("2019-02-28"),
                        Price = 384,
                        Author = "Karol Król",
                        ImageUrl = "/images/image8.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}