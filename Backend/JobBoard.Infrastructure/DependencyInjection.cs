namespace JobBoard.Infrastructure
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
    }
}