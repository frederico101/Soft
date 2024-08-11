using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Soft.Api.ViewModel
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }


        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        [MaxLength(25)]
        public string Category { get; set; }

        [Required]
        public bool IsRented { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; }

        [Required]
        [MaxLength(25)]
        public string Status { get; set; }

        [MaxLength(255)]
        public string CoverPath { get; set; }

        [ScaffoldColumn(false)]
        public HttpPostedFileBase CoverImageUpload { get; set; }

        [ScaffoldColumn(false)]
        public string FormattedCreatedAt => CreatedAt.ToString("yyyy-MM-dd");
        [ScaffoldColumn(false)]
        public string FormattedUpdatedAt => UpdatedAt.ToString("yyyy-MM-dd");
    }
}
