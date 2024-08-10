using System;
using System.ComponentModel.DataAnnotations;
namespace Soft.Api.ViewModel
{
        public class BookViewModel
        {
            public Guid Id { get; set; }

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
            public DateTime CreatedAt { get; set; }

            [Required]
            public DateTime UpdatedAt { get; set; }

            [Required]
            [MaxLength(25)]
            public string Status { get; set; }

            [MaxLength(255)]
            public string CoverPath { get; set; }

            // Additional properties or computed values for view can be added here
            public string FormattedCreatedAt => CreatedAt.ToString("yyyy-MM-dd");
            public string FormattedUpdatedAt => UpdatedAt.ToString("yyyy-MM-dd");
        }
}