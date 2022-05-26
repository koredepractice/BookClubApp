using System.ComponentModel.DataAnnotations;
namespace Bookclub.Models
{
    public class Member //second table in database
    {
        [Key]
        public int MemberId { get; set; } //first column

        [Required(ErrorMessage = "Please enter your name")]
        public string? MemberName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }


    }
}
