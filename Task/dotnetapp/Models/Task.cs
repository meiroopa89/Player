using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Task
    {
        [Key]
        public int Id {get;set;}

        [Required (ErrorMessage = "Name is required")]
        public string Name {get;set;}
        public string Description {get;set;}
    }
}