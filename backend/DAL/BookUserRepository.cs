using DAL.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskerDAL;

namespace DAL
{
    public class BookUserRepository : IRepository<BookUser>
    {
        private readonly ApplicationContext _context;

        public BookUserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(BookUser entity)
        {
            _context.BookUsers.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.BookUsers.Find(id);
            if (entity != null)
            {
                _context.BookUsers.Remove(entity);
            }
        }

        public IEnumerable<BookUser> GetAll()
        {
            return _context.BookUsers
                .Include(ub => ub.Book)
                .AsNoTracking()
                .ToList();
        }

        public IQueryable<BookUser> GetAllQ()
        {
            return _context.BookUsers.Include(ub => ub.Book).AsQueryable();
        }

        public BookUser GetById(int id)
        {
            return _context.BookUsers.Find(id);
        }

        public void Update(BookUser newEntity, int id)
        {
            var existing = _context.BookUsers.Find(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(newEntity);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
