using System;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    public class Enrollment
    {
      
        public int EnrollmentId { get; set; }
        public int UserId{ get; set; }
        public User? User { get; set; }
        
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
       
     
    }
}