namespace JobBoard.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Entities;

    public interface IJobService
    {
        Task<int> AddJob(JobEntity job);

        Task<int> AddJobs(IEnumerable<JobEntity> jobs);
        
        Task<IEnumerable<JobEntity>> GetJobs(Expression<Func<JobEntity, bool>> expression = null);

        Task<JobEntity> GetJob(Expression<Func<JobEntity, bool>> expression = null);

        Task<int> DeleteJob(JobEntity job);

        Task<int> DeleteJobs(IEnumerable<JobEntity> jobs);
     
        Task<int> UpdateJob(JobEntity job);

        Task<int> UpdateJobs(IEnumerable<JobEntity> jobs);
    }
}