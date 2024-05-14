using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Phone
    {
        public int phoneId { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Brand must be between 1 and 50 characters.")]
        public string brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters.")]
        public string model { get; set; }

        [Required(ErrorMessage = "Screen size is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Screen size must be a positive number.")]
        public double screenSize { get; set; }

        [Required(ErrorMessage = "Storage capacity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Storage capacity must be a positive integer.")]
        public int storageCapacity { get; set; }

        [Required(ErrorMessage = "RAM is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "RAM must be a positive integer.")]
        public int ram { get; set; }

        [Required(ErrorMessage = "Battery capacity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Battery capacity must be a positive integer.")]
        public int batteryCapacity { get; set; }
    }
}
