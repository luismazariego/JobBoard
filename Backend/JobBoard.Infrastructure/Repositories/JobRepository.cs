namespace JobBoard.Infrastructure.Repositories
{
    using Core.Entities;
    using Core.Interfaces;
    using Data;

    public class JobRepository : GenericRepository<JobEntity>, IJobRepository
    {
        public JobRepository(JobBoardContext context)
        {
            Context = context;
        }
    }
}