using System.ComponentModel.DataAnnotations;

namespace MealApp.Dtos
{
public class MealReadDto
    {
         [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(250)]
        public string MealName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Recipe { get; set; }



    /*
       public int Id { get; set; }
    
        public string HowTo { get; set; }
      
        public string Line { get; set; }
    
        //public string Platform { get; set; }
        */
    }
}