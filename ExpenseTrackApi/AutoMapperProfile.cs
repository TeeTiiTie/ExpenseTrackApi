using AutoMapper;
using ExpenseTrackApi.DTOs.ExpenseTrack;
using ExpenseTrackApi.DTOs.Master;
using ExpenseTrackApi.Models;

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
            CreateMap<usp_ExpenseGroup_SelectResult, GetExpensesResponseDto>();
            CreateMap<ExpenseLog, GetExpenseLogResponseDto>();
        }
    }
}