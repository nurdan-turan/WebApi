using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BooksStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BooksStoreDBContext>>()))
            {
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }
                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 4,
                        Genre = "Computer1",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 544
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 49,
                        Genre = "Computer2",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 500
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 499,
                        Genre = "Computer3",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 500
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 49,
                        Genre = "Computer",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 500
                    },
                    new Book
                    {
                        Id = 5,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 494,
                        Genre = "Computer",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 500
                    },
                    new Book
                    {
                        Id = 6,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 491,
                        Genre = "Computer",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 300
                    },
                    new Book
                    {
                        Id = 7,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 492,
                        Genre = "Computer",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 500
                    },
                    new Book
                    {
                        Id = 8,
                        Title = "The C Programming Language",
                        Author = "K & R",
                        Price = 100,
                        Genre = "Computer",
                        PublishDate = new DateTime(1984, 8, 10),
                        PageCount = 100
                    }
                );
                context.SaveChanges();

            }
        }
    }
}