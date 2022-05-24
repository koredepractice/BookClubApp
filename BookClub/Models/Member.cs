using System.ComponentModel.DataAnnotations;
namespace BookClubApp.Models
{
    public class Member //second table in database
    {
        [Key]
        public int MemberId { get; set; } //first column

        [Required(ErrorMessage = "Please enter your name")]
        [MinLength(2, ErrorMessage = "Length of publication year cannot be less than 2 characters")]

        public string? MemberName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a rating out of 10, 1 = lowest and 10 = highest")]
       
        public int Rating { get; set; }
    }
}
