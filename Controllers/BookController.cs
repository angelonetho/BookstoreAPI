using BookstoreAPI.Communication.Requests;
using BookstoreAPI.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();
        private static int _currentId = 0;
            
        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] RequestBookJson requestBookJson)
        {

            var book = new Book
            {
                Id = ++_currentId,
                Author = requestBookJson.Author,
                Gender = requestBookJson.Gender,
                Price = requestBookJson.Price,
                Title = requestBookJson.Title,
                Units = requestBookJson.Units
            };
            
            _books.Add(book);

            return Created(string.Empty, book);

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public IActionResult FetchAll()
        {
            var response = new ResponseFetchAllBooksJson()
            {
                Books = _books
            };
            
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public IActionResult Update(int id, [FromBody] RequestBookJson requestBookJson)
        {
            var book = _books.Find(book => book.Id == id);
            if (book == null) return NotFound();

            book.Author = requestBookJson.Author;
            book.Title = requestBookJson.Title;
            book.Gender = requestBookJson.Gender;
            book.Price = requestBookJson.Price;
            book.Units = requestBookJson.Units;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var book = _books.Find(book => book.Id == id);
            if (book == null) return NotFound();
            
            _books.Remove(book);
            return NoContent();

        }
    }
}
