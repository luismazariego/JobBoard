namespace JobBoard.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.DTOs;
    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class JobController : ControllerBase
    {
        private IJobService _service;
        
        private IMapper _mapper;

        public JobController(IJobService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobDto jobDto)
        {
            var job = _mapper.Map<JobEntity>(jobDto);
            
            var result = await _service.AddJob(job);

            return Ok(result);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRange(IEnumerable<JobDto> jobDto)
        {
            var jobs = _mapper.Map<IEnumerable<JobEntity>>(jobDto);
            
            var result = await _service.AddJobs(jobs);

            return Ok(result);
        }
        
        [HttpGet("{jobId:int}")]
        public async Task<IActionResult> Get(int jobId)
        {
            var job = await _service.GetJob(x => x.Job == jobId);
            var response = _mapper.Map<JobDto>(job);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _service.GetJobs();
            var response = _mapper.Map<IEnumerable<JobDto>>(jobs);

            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(int id, JobDto jobDto)
        {
            var job = _mapper.Map<JobEntity>(jobDto);
            job.Job = id;

            var result = await _service.UpdateJob(job);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var job = await _service.GetJob(x => x.Job == id);

            var response = await _service.DeleteJob(job);
            
            return Ok(response);
        }
    }
}