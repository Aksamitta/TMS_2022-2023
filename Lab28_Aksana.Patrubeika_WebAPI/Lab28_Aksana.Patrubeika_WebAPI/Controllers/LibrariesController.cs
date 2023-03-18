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


        [HttpGet]   //read
        public IEnumerable<Book> GetBooks()
        {
            return _libriryContext.Books.ToList();
        }

        [HttpGet]   //Groupping books by ganre
        public IEnumerable<Book> GroupBooks([FromRoute] string ganre)
        {
            var book = _libriryContext.Books.Find(ganre);

            if (ganre != null)
            {
                if (book.Ganre == ganre)
                {
                    return _libriryContext.Books.ToList();
                }                   
            }
            return _libriryContext.Books.ToList();
        }

        [HttpPost]  //Add
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

        [HttpPut]   //Update
        [Route("{id}")]    //чтобы искать по айдишнику, т.е. указываем условно путь
        public IActionResult PutBook([FromRoute] int id, AddBooksViewModel addBook)    //посмотреть все атрибуты для чего они
        {
            //метод нахождения по какому-то полю
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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)    //посмотреть все атрибуты для чего они
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
