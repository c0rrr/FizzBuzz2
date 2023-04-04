using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Imię: ")]
        [Required, MaxLength(100, ErrorMessage ="Maksymalna długość to {1}")]
        public string Name { get; set; }
        [Display(Name = "Rok urodzenia: ")]
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int Year { get; set; }
    }
}