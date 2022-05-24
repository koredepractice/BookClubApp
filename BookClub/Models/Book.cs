using System.ComponentModel.DataAnnotations;

namespace Bookclub.Models
{
    public class Book
        //"Book" is the name of the first table in the database
    {
        [Key]
            public int BookId { get; set; } //first column

            [Required(ErrorMessage = "Title is required")]

            public string? Title { get; set; }

            [Required(ErrorMessage = "Author's Name is required")]
            public string? AuthorName { get; set; }

            [Required(ErrorMessage = "Year of Publication is required")]
            [MinLength(4, ErrorMessage = "Length of publication year cannot be less than 4 characters")]
           public int YearOfPublication { get; set; }



    }
}
