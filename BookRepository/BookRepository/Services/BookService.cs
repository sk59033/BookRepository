using BookRepository.Models;
using BookRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Books> _genericRepository;
        private readonly IGenericRepository<BookStatus> _bookStatusRepository;

        public BookService( IGenericRepository<Books> genericRepository, IGenericRepository<BookStatus> bookStatusRepository)
        {
            _genericRepository = genericRepository;
            _bookStatusRepository = bookStatusRepository;
        }

        public void AddBookDetails(Books book)
        {
            _genericRepository.Insert(book);
        }

        public IEnumerable<BookStatus> GetBookStatusTypes()
        {
            return _bookStatusRepository.GetAll();
        }
        public IEnumerable<Books> GetAllBooks()
        {
            return _genericRepository.GetAll();
        }
        public IEnumerable<Books> GetBookByNameOrAuthor(string name)
        {
            var books = _genericRepository.GetAllList(x=>x.BookName==name || x.AuthorName==name || x.BookName.StartsWith(name) || x.AuthorName.StartsWith(name));
            return books;
        }
        public void UpdateBook(Books book)
        {
            _genericRepository.Update(book);
        }
        public void DeleteBooK(int Id)
        {
            _genericRepository.Delete(Id);
        }

    }
}
