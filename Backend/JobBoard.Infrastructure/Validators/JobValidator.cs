namespace JobBoard.Infrastructure.Validators
{
    using System;
    using Core.DTOs;
    using FluentValidation;

    public class JobValidator : AbstractValidator<JobDto>
    {
        public JobValidator()
        {
            RuleFor(job => job.JobTitle)
                .NotNull()
                .Length(5, 100);
            
            RuleFor(job => job.Description)
                .NotNull()
                .Length(10, 1000);

            RuleFor(job => job.ExpiresAt)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}