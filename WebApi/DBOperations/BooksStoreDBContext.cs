using System;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.DBOperations {
    public class BooksStoreDBContext : DbContext {
      
       public BooksStoreDBContext(DbContextOptions<BooksStoreDBContext> options) : base(options){

        }
    
        public DbSet<Book> Books { get; set; }    
    }
    
    
}
        
        