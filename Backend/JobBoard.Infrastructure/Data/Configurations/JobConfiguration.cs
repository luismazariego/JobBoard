namespace JobBoard.Infrastructure.Data.Configurations
{
    using System;
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class JobConfiguration : IEntityTypeConfiguration<JobEntity>
    {
        public void Configure(EntityTypeBuilder<JobEntity> builder)
        {
            builder.ToTable("Job");

            builder.HasKey(e => e.Job);

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(e => e.JobTitle)
                .HasColumnName("JobTitle")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValue(DateTime.Now);

            builder.Property(e => e.ExpiresAt)
                .HasColumnName("ExpiresAt")
                .IsRequired();
        }
    }
}