using System;
using System.Diagnostics;
using dotnetapp.Models;
using Microsoft.EntityframeworkCore;

namespace dotnetapp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks {get;set;}
    }
}