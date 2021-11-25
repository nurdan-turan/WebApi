using Microsoft.AspNetCore.Mvc;


namespace WebApi.AddControllers {
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase{
        
       private static List<Book> BookList = new List<Book>(){
           
           new Book(){
               Id = 1,
               Title = "BookAA",
               Author = "Author",
               GenreId = 1,
               Price = 1000,
               PublishDate = new DateTime(2020,01,01),
               PageCount = 100,
           },
            new Book(){
              Id = 2,
              Title = "BookBB",
              Author = "Author",
              GenreId = 2,
              Price = 300,
              PublishDate = new DateTime(2010,01,01),
              PageCount = 100,
          },
            new Book(){
              Id = 3,
              Title = "BookCC",
              Author = "Author",
              GenreId = 3,
              Price = 300,
              PublishDate = new DateTime(2021,01,01),
              PageCount = 100,
          }
       };

       [HttpGet]
        public List<Book> GetAllBooks(){
            var bookList = BookList.OrderBy(b => b.Id).ToList();
            return bookList;
        }

       [HttpGet("{id}")]
        public Book GetById(int id){
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id){
            // var book = BookList.Where(book => book.Id == int.Parse(id)).SingleOrDefault();
            // return book;

        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book = BookList.SingleOrDefault(b => b.Title == newBook.Title);
            if(book is not null){
                return BadRequest();
            }
            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook){
            var book = BookList.SingleOrDefault(b => b.Id == updatedBook.Id);
            if(book is null){
                return BadRequest();
            }
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.Price = updatedBook.Price != default ? updatedBook.Price : book.Price;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.Author = updatedBook.Author != default ? updatedBook.Author : book.Author;
            return Ok();

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id){
        var book = BookList.SingleOrDefault(b => b.Id == id);
        if(book is null){
            return BadRequest();
        }
        BookList.Remove(book);
        return Ok();
    }
}
}
