using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace dotnetapp.Models
{
    public class Recipe
    {
        public int id {get;set;}
        [Required(ErrorMessage = "Name is required")]
        public string name {get;set;}
        [Required(ErrorMessage = "Ingredients is required")]
        public string ingredients {get;set;}
    }
}