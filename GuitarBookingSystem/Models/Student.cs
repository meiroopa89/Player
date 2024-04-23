using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarBookingSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int ClassID { get; set; }

        public Class? Class { get; set; }
    }
}
