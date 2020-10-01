using System.ComponentModel.DataAnnotations;

namespace MealApp.Dtos
{
public class MealUpdateDto
    {
        
        [Required, MaxLength(250)]
        public string MealName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Recipe { get; set; }
        
        /*[Required, MaxLength(250)]
        public string HowTo { get; set; }
      
        [Required]
        public string Line { get; set; }
        
        [Required]
        public string Platform { get; set; }
        */
    }
}