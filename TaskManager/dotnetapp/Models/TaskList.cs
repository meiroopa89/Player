using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TaskItem> Tasks { get; set; }
    }
}