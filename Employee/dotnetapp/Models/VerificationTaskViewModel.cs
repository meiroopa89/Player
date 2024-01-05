using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class VerificationTaskViewModel
{
    public int CandidateID { get; set; }
    
    [Required(ErrorMessage = "Verification details are required.")]
    public string VerificationDetails { get; set; }
    
    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; }
}
}
