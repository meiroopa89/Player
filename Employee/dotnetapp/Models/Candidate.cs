
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Candidate
{
    public int CandidateID { get; set; }
    public string CandidateName { get; set; }
    public ICollection<VerificationTask> VerificationTasks { get; set; }
}
}