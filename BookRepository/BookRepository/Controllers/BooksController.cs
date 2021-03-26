using BookRepository.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace BookRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {            
            this._bookService = bookService;
        }


        [HttpGet]
        [Route("GetBookStatusTypes")]
        public IActionResult GetBookStatusTypes()
        {
            IEnumerable<BookStatus> bookStatus = _bookService.GetBookStatusTypes();
            return Ok(bookStatus);
        }
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            IEnumerable<Books> books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        [Route("GetByBookNameOrAuthor")]
        public IActionResult GetByBookNameOrAuthor(string name)
        {
            IEnumerable<Books> books = _bookService.GetBookByNameOrAuthor(name);
            return Ok(books);
        }
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AddBook")]
        public IActionResult AddBook([FromBody] Books model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBookDetails(model);
                return Ok("Book Added Successfully");
            }
            return Ok();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Route("UpdateBook")]
        public IActionResult UpdateBook([FromBody]Books book)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return Ok("Book detail Updated Successfully");
            }
            
            return Ok();
        }

        [HttpPost]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            if (id>0)
            {
                _bookService.DeleteBooK(id);
                return Ok("Book Deleted Successfully");
            }
            return Ok();
        }

    }
}
