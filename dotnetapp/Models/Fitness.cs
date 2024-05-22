using System;
using System.ComponentModel.DataAnnotations;

public class Fitness
{
    [Key]
    public int classId { get; set; }
    
    [Required(ErrorMessage = "Class name is required")]
    public string className { get; set; }
    
    [Required(ErrorMessage = "Instructor name is required")]
    public string instructorName { get; set; }
    
    [Required(ErrorMessage = "Class date is required")]
    public string classDate { get; set; }
    
    [Required(ErrorMessage = "Duration is required")]
    public int duration { get; set; }

    [Required(ErrorMessage = "Location is required")]
    public string location { get; set; }
}
