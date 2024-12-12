using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLi.Chalenge.DAL.Model;
using SQLi.Service;
using SQLi.Chalenge.DTO;
using SQLi.Mapper;

namespace SQLi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Récupérer tous les livres
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // Récupérer un livre par ID
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound("Livre introuvable.");

            return Ok(book);
        }

        // Ajouter un livre
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Book book = BookMapper.BookToBookDTO(bookDTO);
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.id }, book);
        }

        // Mettre à jour un livre
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Book book = BookMapper.BookToBookDTO(bookDTO);
            _bookService.UpdateBook(id, book);
            return NoContent();
        }

        // Supprimer un livre
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (_bookService.GetBookById(id) == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}