namespace JobBoard.Core.DTOs
{
    using System;

    public class JobDto
    {
        public string JobTitle { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}