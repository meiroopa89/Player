using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Recipe
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        public string Ingredients {get;set;}
    }
}