using Bookclub.Data;
using Bookclub.Models;

namespace BookClubApp.Data.Repositories

{
    public class BooksRepository :  ICrudRepository<Book, int>
    {
     
        private readonly BookclubContext _bookclubContext;
        public BooksRepository(BookclubContext bookclubContext)
        {
            _bookclubContext = bookclubContext ?? throw new
            ArgumentNullException(nameof(bookclubContext));
        }
        public void Add(Book element)
        {
            _bookclubContext.Books.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _bookclubContext.Books.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _bookclubContext.Books.Any(u => u.BookId == id);
        }
        public Book Get(int id)
        {
            return _bookclubContext.Books.FirstOrDefault(u => u.BookId == id);
        }
        public IEnumerable<Book> GetAll()
        {
            return _bookclubContext.Books.ToList();
        }
        public bool Save()
        {
            return _bookclubContext.SaveChanges() > 0;
        }
        public void Update(Book element)
        {
            _bookclubContext.Update(element);
        }
    }
}
