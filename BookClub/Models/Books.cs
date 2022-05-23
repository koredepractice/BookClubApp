using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class Books
        //"Books" is the name of the first table in the database
    {
        [Key]
            public int BookId { get; set; } //first column

            [Required(ErrorMessage = "Title is required")]

            [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
            public string? Title { get; set; }

            [Required(ErrorMessage = "Author is required")]
            public string? Author { get; set; }

            [Required(ErrorMessage = "ISBN Number is required")]
            public int ISBN { get; set; }



    }
}
