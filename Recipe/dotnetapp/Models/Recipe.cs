using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Recipe
    {
        
       public int id {get;set;}

        [Required(ErrorMessage ="Name is required")]
       public string Name {get;set;}
        [Required(ErrorMessage ="Ingredients is required")]
       public string Ingredients {get;set;}
    }
}