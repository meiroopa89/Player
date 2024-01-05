using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class VerificationTaskSummary
{
    public string CandidateName { get; set; }
    public int PendingCount { get; set; }
    public int OngoingCount { get; set; }
    public int CompletedCount { get; set; }
}
}



