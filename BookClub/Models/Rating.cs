using System.ComponentModel.DataAnnotations;

namespace Bookclub.Models
{
    public class Rating
    //"RatingScale" is the name of the first table in the database
    {
        [Key]
        public int Id { get; set; } //first column

       
        public string? BookId { get; set; }
        public string? MemberId { get; set; }

        [Required(ErrorMessage = "Please enter a numerical rating out of 5, 1 = lowest and 5 = highest")]
        public int BookRating { get; set; }



    }
}
