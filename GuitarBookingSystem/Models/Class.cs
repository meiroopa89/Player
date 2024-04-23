using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarBookingSystem.Models

{
    public class Class
    {
        [Required(ErrorMessage = "ClassID is required")]
        public int ClassID { get; set; }

        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Students is required")]
        public ICollection<Student> Students { get; set; }
    }
    }
