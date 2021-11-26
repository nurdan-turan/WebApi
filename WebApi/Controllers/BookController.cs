using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;


namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BooksStoreDBContext _context;

        public BookController(BooksStoreDBContext context)
        {
            _context = context;
        }
        //private static List<Book> BookList = new List<Book>(){
        //    new Book(){
        //    Id = 1,
        //    Title = "BookAA",
        //    Author = "AuthorTt",
        //    GenreId = 1,
        //    Price = 1000,
        //    PublishDate = new DateTime(2020,01,01),
        //    PageCount = 100,
        //    },
        // new Book(){
        //   Id = 2,
        //   Title = "BookBB",
        //   Author = "AuthorTest",
        //   GenreId = 2,
        //   Price = 300,
        //   PublishDate = new DateTime(2010,01,01),
        //   PageCount = 100,
        //   },
        // new Book(){
        //   Id = 3,
        //   Title = "BookCC",
        //   Author = "AuthorTest",
        //   GenreId = 3,
        //   Price = 300,
        //   PublishDate = new DateTime(2021,01,01),
        //   PageCount = 100,
        //   }
        //};

        [HttpGet]
        public List<Book> GetAllBooks()
        {
            var bookList = _context.Books.OrderBy(b => b.Id).ToList<Book>();
            return bookList;
        }

        // [HttpGet("{id}")]
        // public Book GetById(int id)
        // {
            // var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            // return book;
        // }

        // [HttpGet]
        // public Book Get([FromQuery] string id){
        // var book = BookList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
        // return book;

        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(b => b.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest();
            }
            _context.Books.Add(newBook);
            _context.SaveChanges(); //Her değişiklik sonra db'ye kaydedilir.
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == updatedBook.Id);
            if (book is null)
            {
                return BadRequest();
            }
            book.Genre = updatedBook.Genre != default ? updatedBook.Genre : book.Genre;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.Price = updatedBook.Price != default ? updatedBook.Price : book.Price;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.Author = updatedBook.Author != default ? updatedBook.Author : book.Author;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book is null)
            {
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
