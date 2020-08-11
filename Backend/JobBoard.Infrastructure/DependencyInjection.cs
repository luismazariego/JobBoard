namespace JobBoard.Infrastructure
{
    using Core.Interfaces;
    using Core.Services;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

    public static class DependencyInjection 
    {
        public static IServiceCollection AddContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<JobBoardContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("JobBoard"))
                );
            
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IUnitOfWork, UnitOfWorkContainer>();
            
            return services;
        }
    }
}