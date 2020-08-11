namespace JobBoard.Infrastructure.Mappings
{
    using AutoMapper;
    using Core.DTOs;
    using Core.Entities;

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<JobEntity, JobDto>()
                .ReverseMap();
        }
    }
}