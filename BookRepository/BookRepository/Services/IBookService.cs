using BookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Services
{
    public interface IBookService
    {
        IEnumerable<BookStatus> GetBookStatusTypes();
        IEnumerable<Books> GetAllBooks();
        IEnumerable<Books> GetBookByNameOrAuthor(string name);
        void AddBookDetails(Books book);
        void UpdateBook(Books book);
        void DeleteBooK(int Id);

    }
}
