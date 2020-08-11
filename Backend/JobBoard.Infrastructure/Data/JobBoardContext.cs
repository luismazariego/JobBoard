namespace JobBoard.Infrastructure.Data
{
    using System.Reflection;
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) 
            : base(options)
        {
        }
        
        public DbSet<JobEntity> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}