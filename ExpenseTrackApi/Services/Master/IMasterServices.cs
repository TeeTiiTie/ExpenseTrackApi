using ExpenseTrackApi.DTOs.Master;

namespace ExpenseTrackApi.Services.Master
{
    public interface IMasterServices
    {
        Task<List<ApplicationResponseDto>> GetApplication(ApplicationRequestDto filter);

        Task<List<BranchResponseDto>> GetBranch(BranchRequestDto filter);
    }
}