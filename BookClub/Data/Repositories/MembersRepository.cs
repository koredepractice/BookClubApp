using Bookclub.Data;
using Bookclub.Models;

namespace BookClubApp.Data.Repositories

{
    public class MembersRepository : ICrudRepository<Member, int>
    {

        private readonly BookclubContext _bookclubContext;
        public MembersRepository(BookclubContext bookclubContext)
        {
            _bookclubContext = bookclubContext ?? throw new
            ArgumentNullException(nameof(bookclubContext));
        }
        public void Add(Member element)
        {
            _bookclubContext.Members.Add(element);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _bookclubContext.Members.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _bookclubContext.Members.Any(u => u.MemberId == id);
        }
        public Member Get(int id)
        {
            return _bookclubContext.Members.FirstOrDefault(u => u.MemberId == id);
        }
        public IEnumerable<Member> GetAll()
        {
            return _bookclubContext.Members.ToList();
        }
        public bool Save()
        {
            return _bookclubContext.SaveChanges() > 0;
        }
        public void Update(Member element)
        {
            _bookclubContext.Update(element);
        }
    }
}
