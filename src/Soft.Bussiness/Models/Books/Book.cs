using FluentValidation.Results;
using Soft.Bussiness.Models.Books;
using System;

namespace Soft.Bussiness.Models.Books
{ 
    public class Book : Entity
    {

   
        public string Title { get; set; }

     
        public string Author { get; set; }

       
        public string Category { get; set; }

       
        public bool IsRented { get; set; }

       
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

      
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

      
        public string Status { get; set; }

      
        public string CoverPath { get; set; }

        public ValidationResult Validate() 
        {
            var validate = new BookValidation();
            var result = validate.Validate(this);
            return result;
        }      
        
    }
 }

