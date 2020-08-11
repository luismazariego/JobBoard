namespace JobBoard.Infrastructure.Repositories
{
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Data;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UnitOfWorkContainer : IUnitOfWork
    {
        private readonly JobBoardContext _context;

        public UnitOfWorkContainer(JobBoardContext context)
        {
            _context = context;
            Repository = new UnitOfWorkRepository(_context);
        }
        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public IUnitOfWorkRepository Repository { get; }
    }
}