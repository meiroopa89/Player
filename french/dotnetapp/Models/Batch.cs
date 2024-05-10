using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Batch
    {
        public int BatchID { get; set; }

        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; } // Cost associated with the batch

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; } // Duration of the batch in hours
        public virtual ICollection<Student> Students { get; set; }
    }
}
