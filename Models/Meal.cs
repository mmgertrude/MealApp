using System.ComponentModel.DataAnnotations;

namespace MealApp.Models
{
public class Meal
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(250)]
        public string MealName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Recipe { get; set; }
    }
}