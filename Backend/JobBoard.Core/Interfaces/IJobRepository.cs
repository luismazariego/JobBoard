namespace JobBoard.Core.Interfaces
{
    using Entities;

    public interface IJobRepository : ICreateRepository<JobEntity>,
        IReadRepository<JobEntity>, IRemoveRepository<JobEntity>,
        IUpdateRepository<JobEntity>
    {
    }
}