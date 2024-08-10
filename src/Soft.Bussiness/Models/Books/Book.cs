using Soft.Bussiness;
using System;
using System.ComponentModel.DataAnnotations;


    public class Book : Entity
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(25)]
        public string Category { get; set; }

        [Required]
        public bool IsRented { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(25)]
        public string Status { get; set; }

        [MaxLength(255)]
        public string CoverPath { get; set; }
    }

