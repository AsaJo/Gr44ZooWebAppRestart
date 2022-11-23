using System.ComponentModel.DataAnnotations;

namespace Gr44ZooWebApp.Models.ViewModels
{
    public class CreateAnimalViewModel
    {
        [Display(Name ="Animal")]
        [Required]
        public string? AnimalName { get; set; }
        [Required]
        public string? Species { get; set; }
        [StringLength(80, MinimumLength = 1)]
        [Required]
        public string? CalledByName { get; set; }
        public double Quantity { get; set; }

        public List<string> SpeciesList
        {
            get
            {
                return new List<string>

                { "Mammal", "Reptile", "Fishes","Insects","Birds"," Spineless" };
            }
        }
    }

}
