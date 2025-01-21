using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExpenseTrackApi.Data;
using ExpenseTrackApi.Models;
using ExpenseTrackApi.DTOs.Master;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackApi.Services.Master
{
    public class MasterServices : IMasterServices
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public MasterServices(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ApplicationResponseDto>> GetApplication(ApplicationRequestDto filter)
        {
            var qry = _context.Applications.Where(x => x.IsActive == true && filter.SchoolYear == filter.SchoolYear && x.Status_id == "3040");

            qry = FilterApplication(qry, filter);

            var dto = await qry.ProjectTo<ApplicationResponseDto>(_mapper.ConfigurationProvider).ToListAsync();

            return dto;
        }

        private IQueryable<Application> FilterApplication(IQueryable<Application> qry, ApplicationRequestDto filter)
        {
            if (filter.BranchId.HasValue)
                qry = qry.Where(x => x.BranchId == filter.BranchId);

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                if (filter.SearchText.Length > 3)
                {
                    qry = qry.Where(x => x.ApplicationCode.Contains(filter.SearchText) || x.SchoolName.Contains(filter.SearchText));
                }
            }

            return qry;
        }

        public async Task<List<BranchResponseDto>> GetBranch(BranchRequestDto filter)
        {
            var qry = _context.Branches.Where(x => x.IsActive == true);

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
                qry = qry.Where(x => x.BranchName.Contains(filter.SearchText) || x.BranchCode.Contains(filter.SearchText));

            var dto = await qry.ProjectTo<BranchResponseDto>(_mapper.ConfigurationProvider).ToListAsync();
            return dto;
        }
    }
}