using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(100, ErrorMessage = "Specialization must be between 1 and 100 characters.")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(20, ErrorMessage = "Phone number must be between 1 and 20 characters.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, ErrorMessage = "Email must be between 1 and 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address must be between 1 and 200 characters.")]
        public string Address { get; set; }
    }
}
