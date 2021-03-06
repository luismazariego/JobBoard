﻿namespace JobBoard.Core.DTOs
{
    using System;

    public class JobDto
    {
        public int Job { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }
                
        public DateTime ExpiresAt { get; set; }
    }
}