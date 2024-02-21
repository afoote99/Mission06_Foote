using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Foote.Models
{
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Sorry, you need to enter a category")]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(1880, 2024)]
        public int Year { get; set; } = 0;
        [Required]
        public string Director { get; set; }

        [ForeignKey("RatingId")]
        public int? RatingId { get; set; }

        public Rating? Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

    }
}
