using Bookclub.Models;
using BookClubApp.Data.Repositories;

namespace BookClubApp.Services
{
    public class MembersService : ICrudService<Member, int>
    {
        private readonly ICrudRepository<Member, int> _membersRepository;
        public MembersService(ICrudRepository<Member, int> membersRepository)
        {
            _membersRepository = membersRepository;
        }
        public void Add(Member element)
        {
            _membersRepository.Add(element);
            _membersRepository.Save();
        }
        public void Delete(int id)
        {
            _membersRepository.Delete(id);
            _membersRepository.Save();
        }
        public Member Get(int id)
        {
            return _membersRepository.Get(id);
        }
        public IEnumerable<Member> GetAll()
        {
            return _membersRepository.GetAll();
        }
        public void Update(Member old, Member newT)
        {
            old.MemberName = newT.MemberName;
            old.Email = newT.Email;
            _membersRepository.Update(old);
            _membersRepository.Save();
        }
    }
}
