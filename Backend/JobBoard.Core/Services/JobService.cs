namespace JobBoard.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Entities;
    using Interfaces;

    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<int> AddJob(JobEntity job)
        {
            await _unitOfWork.Repository.JobRepository.AddAsync(job);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> AddJobs(IEnumerable<JobEntity> jobs)
        {
            await _unitOfWork.Repository.JobRepository.AddAsync(jobs);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobEntity>> GetJobs(Expression<Func<JobEntity, bool>> expression)
        {
            return await _unitOfWork.Repository.JobRepository.GetAllAsync(expression);
        }

        public async Task<JobEntity> GetJob(Expression<Func<JobEntity, bool>> expression)
        {
            return await _unitOfWork.Repository.JobRepository.SingleAsync(expression);
        }

        public async Task<int> DeleteJob(JobEntity job)
        {
            _unitOfWork.Repository.JobRepository.Remove(job);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteJobs(IEnumerable<JobEntity> jobs)
        {
            _unitOfWork.Repository.JobRepository.Remove(jobs);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> UpdateJob(JobEntity job)
        {
            _unitOfWork.Repository.JobRepository.Update(job);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> UpdateJobs(IEnumerable<JobEntity> jobs)
        {
            _unitOfWork.Repository.JobRepository.Update(jobs);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}