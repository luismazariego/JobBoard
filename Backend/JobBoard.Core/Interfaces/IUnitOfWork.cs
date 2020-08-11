namespace JobBoard.Core.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Storage;

    public interface IUnitOfWork
    {
        void DetectChanges();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();

        IUnitOfWorkRepository Repository { get; }
    }
}