using DAL.UnitOfWork;
using Domain;
using OnlineLibrary_BookKey.DTO.Book;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace BLL.BookService
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Книга не може бути пуста");
            }
            _unitOfWork.BookRepository.Add(book);
            _unitOfWork.Save();
        }

        public void DeleteBook(int id)
        {
            var book = _unitOfWork.BookRepository.GetById(id);
            if (book != null)
            {
                _unitOfWork.BookRepository.Delete(id);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<Book> GetAllBooks(BookQueryParameters query)
        {
            var booksQuery = _unitOfWork.BookRepository.GetAllQ();
            // 2. Фільтруємо (Пошук)
            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                booksQuery = booksQuery.Where(b => b.Title.ToLower().Contains(query.SearchTerm.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(query.Author))
            {
                booksQuery = booksQuery.Where(b => b.Author == query.Author);
            }

            // 4. Сортуємо (тільки актуальне для бібліотеки)
            booksQuery = query.SortBy switch
            {
                "newest" => booksQuery.OrderByDescending(b => b.Year), // Спочатку нові
                "oldest" => booksQuery.OrderBy(b => b.Year),           // Спочатку старі
                "title" => booksQuery.OrderBy(b => b.Title),          // За алфавітом
                _ => booksQuery.OrderBy(b => b.Id)                     // За замовчуванням
            };

            // 5. Пагінація
            return booksQuery
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToList();
        }

        public Book GetBookById(int id)
        {
            return _unitOfWork.BookRepository.GetById(id);
        }

        public IEnumerable<Book> GetBooksByUserId(string userId)
        {
            return _unitOfWork.BookRepository.GetAllQ()
                .Where(x => x.Author == userId)
                .ToList();
        }

        public void UpdateBook(int id, Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (book.Id != id)
            {
                book.Id = id;
            }

            _unitOfWork.BookRepository.Update(book, id);
            _unitOfWork.Save();
        }
    }
}
