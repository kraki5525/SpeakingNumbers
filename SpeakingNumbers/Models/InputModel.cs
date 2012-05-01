using System.ComponentModel.DataAnnotations;

namespace SpeakingNumbers.Models
{
    public class InputModel
    {
        public InputModel()
        {
            NumberAsString = "";
        }

        [Required(ErrorMessage = "You must enter a number.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "You can only enter a valid natural number.")]
        public string NumberAsString { get; set; } 
    }
}