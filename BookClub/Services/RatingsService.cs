using Bookclub.Models;
using BookClubApp.Data.Repositories;

namespace BookClubApp.Services
{
    public class RatingsService : ICrudService<Rating, int>
    {
        private readonly ICrudRepository<Rating, int> _ratingsRepository;
        public RatingsService(ICrudRepository<Rating, int> ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }
        public void Add(Rating element)
        {
            _ratingsRepository.Add(element);
            _ratingsRepository.Save();
        }
        public void Delete(int id)
        {
            _ratingsRepository.Delete(id);
            _ratingsRepository.Save();
        }
        public Rating Get(int id)
        {
            return _ratingsRepository.Get(id);
        }
        public IEnumerable<Rating> GetAll()
        {
            return _ratingsRepository.GetAll();
        }
        public void Update(Rating old, Rating newT)
        {
            old.BookRating = newT.BookRating;
            _ratingsRepository.Update(old);
            _ratingsRepository.Save();
        }

    //    public IEnumerable<string> GetAllBookRating
    //    {
    //        return ((RatingsService) _ratingsService).GetAllBookRating();
    //    }
    }
}