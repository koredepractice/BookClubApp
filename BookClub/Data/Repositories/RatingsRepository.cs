using Bookclub.Data;
using Bookclub.Models;

namespace BookClubApp.Data.Repositories

{
    public class RatingsRepository : ICrudRepository<Rating, int>
    {

        private readonly BookclubContext _bookclubContext;
        public RatingsRepository(BookclubContext bookclubContext)
        {
            _bookclubContext = bookclubContext ?? throw new
            ArgumentNullException(nameof(bookclubContext));
        }
        public void Add(Rating element)
        {
            _bookclubContext.Ratings.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _bookclubContext.Ratings.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _bookclubContext.Ratings.Any(u => u.Id == id);
        }
        public Rating Get(int id)
        {
            return _bookclubContext.Ratings.FirstOrDefault(u => u.Id == id);
        }
        public IEnumerable<Rating> GetAll()
        {
            return _bookclubContext.Ratings.ToList();
        }
        public bool Save()
        {
            return _bookclubContext.SaveChanges() > 0;
        }
        public void Update(Rating element)
        {
            _bookclubContext.Update(element);
        }

        //An attempt to join the three table sin the database

        //public IEnumerable<string> GetAllBookRatings()
        //{
        //    List<Book> books = BookclubContext.book.ToList();
        //    List<Member> members = BookclubContext.member.ToList();
        //    List<Rating> ratings = BookclubContext.rating.ToList();

        //}
        //var result = from BookId in Book
        //             join BookId in Rating
        //             on BookId.BookId equals Book.Id
        //             join MemberId in Rating
        //             on MemberId in Member

        //             select $"{Book.BookId} {Rating.BookId} "
                     
        //return result




}
}