using AutoMapper;
using ExpenseTrack.Models;
using ExpenseTrackApi.DTOs.Master;

namespace ExpenseTrackApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*
             * CreateMap<SampleMessage, ExampleModels>()
             *     .ForMember(_ => _.ExampleName, _ => _.MapFrom(_ => _.Name))
             *     .ReverseMap();
             *
             * CreateMap<ExampleModels, GetExampleReponseDto>();
             */
            // Master
            CreateMap<Application, ApplicationResponseDto>();
            CreateMap<Branch, BranchResponseDto>();
        }
    }
}