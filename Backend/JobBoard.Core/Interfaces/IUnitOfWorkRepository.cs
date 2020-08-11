namespace JobBoard.Core.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        IJobRepository JobRepository { get; }
    }
}