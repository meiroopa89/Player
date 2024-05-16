using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Flight : IValidatableObject
    {
        public int flightId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Airline must be between 1 and 50 characters.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Departure airport is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Departure airport must be between 1 and 100 characters.")]
        public string departureAirport { get; set; }

        [Required(ErrorMessage = "Destination airport is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Destination airport must be between 1 and 100 characters.")]
        public string destinationAirport { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.Date)]
        public DateTime departureDate { get; set; }

        [Required(ErrorMessage = "Arrival date is required.")]
        [DataType(DataType.Date)]
        public DateTime arrivalDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (arrivalDate < departureDate)
            {
                yield return new ValidationResult("Arrival date must be after departure date.", new[] { nameof(arrivalDate) });
            }
        }
    }
}
