using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Car
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Make must be between 1 and 50 characters.")]
        [Display(Name = "Make")]
        public string make { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters.")]
        [Display(Name = "Model")]
        public string model { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Year must be 4 characters long.")]
        public string year { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Color must be between 1 and 20 characters.")]
        public string color { get; set; }

        [Required(ErrorMessage = "Mileage is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage must be a positive number.")]
        public int mileage { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal price { get; set; }
    }
}
