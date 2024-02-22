using System.ComponentModel.DataAnnotations;

namespace Mission06_Foote.Models
{
    //setting up foreign key table for Categories
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
