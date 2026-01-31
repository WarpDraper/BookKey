using DAL.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskerDAL;

namespace DAL
{
    public class BookRepository : IRepository<Book>
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            // AsNoTracking() пришвидшує читання, якщо ти просто виводиш список 
            // і не збираєшся його тут же редагувати.
            return _context.Books.AsNoTracking().ToList();
        }

        public IQueryable<Book> GetAllQ()
        {
            return _context.Books.AsQueryable();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Update(Book newEntity, int id)
        {
            var existingBook = _context.Books.Find(id);

            if (existingBook != null)
            {
                _context.Entry(existingBook).CurrentValues.SetValues(newEntity);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
