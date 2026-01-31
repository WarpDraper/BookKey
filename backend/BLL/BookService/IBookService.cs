using Domain;
using OnlineLibrary_BookKey.DTO.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BookService
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(BookQueryParameters query);
        Book GetBookById(int id);
        void AddBook(Book book);

        void UpdateBook(int id, Book book);
        void DeleteBook(int id);
        IEnumerable<Book> GetBooksByUserId(string userId);
    }
}
