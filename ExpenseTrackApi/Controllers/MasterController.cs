using ExpenseTrack.Models;
using ExpenseTrackApi.DTOs.Master;
using ExpenseTrackApi.Models;
using ExpenseTrackApi.Services.Master;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ExpenseTrackApi.Controllers
{
    [Route("api/expensetrack/master")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterServices _services;
        private readonly Serilog.ILogger _logger;

        public MasterController(IMasterServices services)
        {
            _services = services;
            _logger = Log.ForContext<MasterController>();
        }

        private const string _controllerName = nameof(MasterController);

        [HttpGet("application", Name = "GetApplication")]
        public async Task<ServiceResponse<List<ApplicationResponseDto>>> GetApplication([FromQuery] ApplicationRequestDto filter)
        {
            try
            {
                var response = await _services.GetApplication(filter);
                return ResponseResult.Success(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "[{ControllerName}] - GetApplication error ", _controllerName);
                return ResponseResult.Failure<List<ApplicationResponseDto>>("เกิดข้อผิดพลาดที่ระบบ กรุณาติดต่อ IT Support");
            }
        }

        [HttpGet("branch", Name = "GetBranch")]
        public async Task<ServiceResponse<List<BranchResponseDto>>> GetBranch([FromQuery] BranchRequestDto filter)
        {
            try
            {
                var response = await _services.GetBranch(filter);
                return ResponseResult.Success(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "[{ControllerName}] - GetBranch error ", _controllerName);
                return ResponseResult.Failure<List<BranchResponseDto>>("เกิดข้อผิดพลาดที่ระบบ กรุณาติดต่อ IT Support");
            }
        }
    }
}