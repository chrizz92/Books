using System;
using System.Collections.Generic;
using System.Text;
using Books.Core.Entities;

namespace Books.Core.Contracts
{
    public interface IBookRepository
    {
        int Count();
        ICollection<Book> GetBooksByPublisher(int id);
        ICollection<Book> GetAllBooks();
        void DeleteBook(int bookId);
        void SaveNewBook(Book book);
    }
}
