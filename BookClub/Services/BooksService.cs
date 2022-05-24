using Bookclub.Models;
using BookClubApp.Data.Repositories;

namespace BookClubApp.Services
{
    public class BooksService : ICrudService<Book, int>
    {
        private readonly ICrudRepository<Book, int> _booksRepository;
        public BooksService(ICrudRepository<Book, int> booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public void Add(Book element)
        {
            _booksRepository.Add(element);
            _booksRepository.Save();
        }
        public void Delete(int id)
        {
            _booksRepository.Delete(id);
            _booksRepository.Save();
        }
        public Book Get(int id)
        {
            return _booksRepository.Get(id);
        }
        public IEnumerable<Book> GetAll()
        {
            return _booksRepository.GetAll();
        }
        public void Update(Book old, Book newT)
        {
            old.Title = newT.Title;
            old.AuthorName = newT.AuthorName;
            old.YearOfPublication = newT.YearOfPublication;
            _booksRepository.Update(old);
            _booksRepository.Save();
        }
    }
}
