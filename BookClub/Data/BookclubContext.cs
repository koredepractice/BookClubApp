using Microsoft.EntityFrameworkCore;
using Bookclub.Models;

namespace Bookclub.Data
{
    public class BookclubContext : DbContext

    {
        public BookclubContext(DbContextOptions<BookclubContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        //public DbSet<Rating> Ratings { get; set; }
    }
}
