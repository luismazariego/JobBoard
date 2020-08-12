namespace JobBoard.App.Models
{
    using System;

    public class Job
    {
        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}