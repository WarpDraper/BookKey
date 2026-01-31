using AutoMapper;
using BLL.BookService;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary_BookKey.DTO.Book;

namespace OnlineLibrary_BookKey.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public BookController(IBookService bookService, IMapper mapper, IWebHostEnvironment env)
        {
            _bookService = bookService;
            _mapper = mapper;
            _env=env;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<BookDto>> GetAll([FromQuery] BookQueryParameters query)
        {
            var books = _bookService.GetAllBooks(query);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }

        // 2. ОТРИМАТИ ОДНУ (Бачать усі)
        // GET: api/book/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<BookDto> GetById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound("Книгу не знайдено");

            return Ok(_mapper.Map<BookDto>(book));
        }

        // 3. СТВОРИТИ (Тільки Адмін!)
        // POST: api/book
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([FromBody] CreateBookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var book = _mapper.Map<Book>(bookDto);

            // Якщо адмін не передав картинку, можна поставити заглушку
            if (string.IsNullOrEmpty(book.Image))
                book.Image = "https://mysite.com/images/default-book.png";

            _bookService.AddBook(book);

            // Повертаємо 201 Created і посилання на нову книгу
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, _mapper.Map<BookDto>(book));
        }

        // 4. ОНОВИТИ (Тільки Адмін!)
        // PUT: api/book/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id, [FromBody] UpdateBookDto bookDto)
        {
            if (id != bookDto.Id && bookDto.Id != 0) return BadRequest("ID не співпадають");

            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null) return NotFound();

            // Маппер оновить тільки ті поля, що прийшли
            _mapper.Map(bookDto, existingBook);

            _bookService.UpdateBook(id, existingBook);
            return NoContent(); // 204 (Успіх, але без контенту)
        }

        // 5. ВИДАЛИТИ (Тільки Адмін!)
        // DELETE: api/book/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();

            _bookService.DeleteBook(id);
            return NoContent();
        }

        // 6. ЗАВАНТАЖИТИ ОБКЛАДИНКУ (Тільки Адмін!)
        // POST: api/book/upload-cover/5
        [HttpPost("upload-cover/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadCover(int id, IFormFile file)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound("Книги немає");

            if (file == null || file.Length == 0) return BadRequest("Файл пустий");
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                return BadRequest("Тільки картинки!");
            string folder = Path.Combine(_env.WebRootPath, "images");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string uniqueName = $"{Guid.NewGuid()}{ext}";
            string fullPath = Path.Combine(folder, uniqueName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Формуємо URL
            string url = $"{Request.Scheme}://{Request.Host}/images/{uniqueName}";
            book.Image = url;
            _bookService.UpdateBook(id, book);

            return Ok(new { url });
        }
    }
}
