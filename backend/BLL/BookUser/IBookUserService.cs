using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BookUser
{
    public interface IBookUserService
    {
        void AddToMyLibrary(string userId, int bookId);
        IEnumerable<Domain.BookUser> GetMyBooks(string userId);
        void MarkAsFinished(string userId, int bookId);
    }
}
