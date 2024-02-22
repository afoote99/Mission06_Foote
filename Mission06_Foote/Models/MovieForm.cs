using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Foote.Models
{
    //going through and setting the columns we have in the database
    //also setting which vlaues are required to submit a movie 
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Categories")]
        public int? CategoryId { get; set; }
        public Categories? Categories { get; set; }

        //setting custom error msg
        [Required (ErrorMessage ="Please enter a title.")]
        public string Title { get; set; }

        //setting custom error msg
        [Required]
        [Range(1888, 100000, ErrorMessage = "You must enter in a year after 1888.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        //setting custom error msg
        [Required (ErrorMessage ="You must check True or False")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        //setting custom error msg
        [Required(ErrorMessage = "You must check True or False")]
        public bool? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

    }
}
