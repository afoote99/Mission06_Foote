using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Foote.Models
{
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Categories")]
        public int? CategoryId { get; set; }
        public Categories? Categories { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 100000)]
        public int Year { get; set; } = 0;

        public string? Director { get; set; }

        public string? Rating { get; set; }
        [Required]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }
        [Required]
        public bool? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }

    }
}
