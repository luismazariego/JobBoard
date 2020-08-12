namespace JobBoard.WebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class JobViewModel
    {
        public int Job { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiresAt { get; set; }
    }
}
