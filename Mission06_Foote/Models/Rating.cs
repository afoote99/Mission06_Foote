using System.ComponentModel.DataAnnotations;

namespace Mission06_Foote.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public string RatingName { get; set; }
    }
}
