using AutoMapper;
using BLL.BookUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary_BookKey.DTO.Book;
using OnlineLibrary_BookKey.DTO.BookUser;
using System.Security.Claims;

namespace OnlineLibrary_BookKey.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookUserController : ControllerBase
    {
        private readonly IBookUserService _bookUserService;
        private readonly IMapper _mapper;

        public BookUserController(IBookUserService bookUserService, IMapper mapper)
        {
            _bookUserService = bookUserService;
            _mapper = mapper;
        }

        // 1. ОТРИМАТИ МОЮ БІБЛІОТЕКУ
        // GET: api/bookuser/my-books
        [HttpGet("my-books")]
        public ActionResult<IEnumerable<UserLibraryDto>> GetMyBooks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            // Отримуємо список BookUser (зв'язків)
            var bookUsers = _bookUserService.GetMyBooks(userId);

            // Перетворюємо в UserLibraryDto (з галочкою IsFinished)
            var libraryDto = _mapper.Map<IEnumerable<UserLibraryDto>>(bookUsers);

            return Ok(libraryDto);
        }

        // 2. ДОДАТИ КНИГУ СОБІ
        // POST: api/bookuser/add/5
        [HttpPost("add/{bookId}")]
        public IActionResult AddToLibrary(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            _bookUserService.AddToMyLibrary(userId, bookId);

            return Ok("Книгу додано в твою бібліотеку");
        }

        // 3. ПОЗНАЧИТИ ЯК ПРОЧИТАНЕ
        // PUT: api/bookuser/finish/5
        [HttpPut("finish/{bookId}")]
        public IActionResult MarkAsRead(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            _bookUserService.MarkAsFinished(userId, bookId);

            return Ok("Вітаю! Книгу прочитано.");
        }
    }
}
