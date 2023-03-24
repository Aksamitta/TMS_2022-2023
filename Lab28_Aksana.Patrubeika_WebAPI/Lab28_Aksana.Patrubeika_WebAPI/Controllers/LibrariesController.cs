using Lab28_Aksana.Patrubeika_WebAPI.Data;
using Lab28_Aksana.Patrubeika_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

namespace Lab28_Aksana.Patrubeika_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrariesController : Controller
    {
        private readonly LibraryContext _libriryContext;

        public LibrariesController(LibraryContext libriryContext)
        {
            _libriryContext = libriryContext;
        }


        /// <summary>
        /// Get all books from the library
        /// </summary>
        /// <remarks>This method shows all books which there are in the library</remarks>
        /// <returns>List of books</returns>
        [HttpGet] 
        [Route("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            return _libriryContext.Books.ToList();
        }

        /// <summary>
        /// Get books by Id of the book
        /// </summary>
        /// <remarks>This method shows book with searching id</remarks>
        /// <param name="id">The Id of the desired book</param>
        [HttpGet]
        [Route("GetBooksById/{id}")]
        public IActionResult GetBooksByAId([FromRoute]int id)
        {
            var book = _libriryContext.Books.Find(id);

            if (book != null)
            {
                return Ok(book);
            };
            return NotFound();
        }

        /// <summary>
        /// Add book to the library
        /// </summary>
        /// <remarks>This method added a book to the library, enter information about the book</remarks>
        [HttpPost("PostBooks")]  //Add
        public IEnumerable<Book> PostBooks(AddBooksViewModel addBook)
        {
            var book = new Book
            {
                BookName = addBook.BookName,
                AuthorName = addBook.AuthorName,
                Year = addBook.Year,
                Price = addBook.Price,
                Ganre = addBook.Ganre

            };
            _libriryContext.Add(book);
            _libriryContext.SaveChanges();
            return _libriryContext.Books.ToList();
        }

        /// <summary>
        /// Update information about a book
        /// </summary>
        /// <remarks>This method updates information about book in the library</remarks>
        /// <param name="id">The Id of the desired book</param>
        [HttpPut]   //Update
        [Route("PutBook/{id}")] 
        public IActionResult PutBook([FromRoute] int id, AddBooksViewModel addBook)    //посмотреть все атрибуты для чего они
        {            
            var book = _libriryContext.Books.Find(id);

            if (book != null)
            {
                book.BookName = addBook.BookName;
                book.AuthorName = addBook.AuthorName;
                book.Year = addBook.Year;
                book.Price = addBook.Price;
                book.Ganre = addBook.Ganre;

                _libriryContext.SaveChanges();
                return Ok(_libriryContext.Books.ToList());
            };
            return NotFound();
        }

        /// <summary>
        /// Delete a book from library
        /// </summary>
        /// <remarks>This method deletes a book from library, enter the id of the book</remarks>
        /// <param name="id">The Id of the desired book</param>
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public IActionResult DeleteBook([FromRoute] int id) 
        {
            //метод нахождения по какому-то полю
            var book = _libriryContext.Books.Find(id);

            if (book != null)
            {
                _libriryContext.Books.Remove(book);
                _libriryContext.SaveChanges();
                return Ok(_libriryContext.Books.ToList());
            };
            return NotFound(); ;
        }
    }
}
