namespace JobBoard.WebApp.Models
{
    using System;

    public class JobViewModel
    {
        public int Job { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
