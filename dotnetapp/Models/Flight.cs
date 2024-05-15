using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Flight : IValidatableObject
    {
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Airline must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Departure airport is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Departure airport must be between 1 and 100 characters.")]
        public string DepartureAirport { get; set; }

        [Required(ErrorMessage = "Destination airport is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Destination airport must be between 1 and 100 characters.")]
        public string DestinationAirport { get; set; }

        [Required(ErrorMessage = "Departure date is required.")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Arrival date is required.")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ArrivalDate < DepartureDate)
            {
                yield return new ValidationResult("Arrival date must be after departure date.", new[] { nameof(ArrivalDate) });
            }
        }
    }
}
