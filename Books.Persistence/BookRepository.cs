using System.Collections.Generic;
using System.Linq;
using Books.Core.Contracts;
using Books.Core.Entities;

namespace Books.Persistence
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Count()
        {
            return _dbContext.Books.Count();
        }

        public void DeleteBook(int bookId)
        {
            _dbContext.Books.Remove(_dbContext.Books.Where(b => b.Id == bookId).First());
            _dbContext.SaveChanges();
            
        }

        public ICollection<Book> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public ICollection<Book> GetBooksByPublisher(int publisherId)
        {
            return _dbContext.Books.Where(b => b.Publisher_Id == publisherId).ToList();
        }

        public void SaveNewBook(Book book)
        {
            _dbContext.Books.Add(book);
        }
    }
}