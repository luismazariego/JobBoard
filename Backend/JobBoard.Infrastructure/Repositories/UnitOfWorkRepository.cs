namespace JobBoard.Infrastructure.Repositories
{
    using Core.Interfaces;
    using Data;

    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IJobRepository JobRepository { get; }
        
        public UnitOfWorkRepository(JobBoardContext context)
        {
            JobRepository = new JobRepository(context);    
        }
    }
}