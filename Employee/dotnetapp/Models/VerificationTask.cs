using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class VerificationTask
{
    public int TaskID { get; set; }
    public int CandidateID { get; set; }
    public string VerificationDetails { get; set; }
    public string Status { get; set; }
    public Candidate Candidate { get; set; }
}
}