using BLL;
using BLL.BookUser;
using DAL.UnitOfWork;
using Domain;
using BookUserEntity = Domain.BookUser; // Change alias to avoid namespace/type ambiguity

namespace BLL.Services
{
    public class BookUserService : IBookUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddToMyLibrary(string userId, int bookId)
        {
            // Перевіряємо дублікати
            var existingRecord = _unitOfWork.BookUserRepository.GetAllQ()
                .FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);

            if (existingRecord != null) return;

            var bookUser = new BookUserEntity
            {
                UserId = userId,
                BookId = bookId,
                AddedDate = DateTime.UtcNow,
                IsFinished = false
            };

            _unitOfWork.BookUserRepository.Add(bookUser);
            _unitOfWork.Save();
        }

        public IEnumerable<BookUserEntity> GetMyBooks(string userId)
        {
            // Репозиторій вже робить Include(x => x.Book), тому книга підтягнеться автоматично
            return _unitOfWork.BookUserRepository.GetAllQ()
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public void MarkAsFinished(string userId, int bookId)
        {
            var record = _unitOfWork.BookUserRepository.GetAllQ()
                .FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);

            if (record != null)
            {
                record.IsFinished = true;
                _unitOfWork.BookUserRepository.Update(record, record.Id);
                _unitOfWork.Save();
            }
        }
    }
}