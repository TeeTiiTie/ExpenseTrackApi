using ExpenseTrackApi.DTOs.ExpenseTrack;
using ExpenseTrackApi.Models;
using ExpenseTrackApi.Services.Auth;
using ExpenseTrackApi.Services.ExpenseTrack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackApi.Controllers
{
    [Route("api/expensetrack")]
    [ApiController]
    [Authorize]
    public class ExpenseTrackController : ControllerBase
    {
        private readonly IExpenseTrackServices _services;
        private readonly ILoginDetailServices _login;
        private readonly Serilog.ILogger? _logger;

        public ExpenseTrackController(IExpenseTrackServices services, ILoginDetailServices login, Serilog.ILogger? logger = null)
        {
            _services = services;
            _login = login;
            _logger = logger?.ForContext("ControllerName", nameof(ExpenseTrackController)) ?? Serilog.Log.ForContext("ControllerName", nameof(ExpenseTrackController));
        }

        private const string _controllerName = nameof(ExpenseTrackController);

        [HttpPost("createexpensetrack", Name = "CreateExpenseTrack")]
        public async Task<ServiceResponse<CreateExpenseTrackResponseDto>> CreateExpenseTrack([FromBody] CreateExpenseTrackRequestDto input)
        {
            try
            {
                //Validate
                var sumAmount = input.CreateExpenseTrackDetails.Sum(x => x.Amount);

                if (input.TotalAmount != sumAmount)
                    return ResponseResult.Failure<CreateExpenseTrackResponseDto>("กรูณาตรวจสอบจำนวนเงิน");

                var claim = _login.GetClaim();

                string userName = $"{claim.Firstname} {claim.Lastname}";

                var response = await _services.InsertExpenseTrack(input, claim.UserId, claim.EmployeeCode, userName);

                string expenseDetail = "สร้างรายการ/สถานะ: รอโอน";
                await _services.InsertExpenseLog(response.Data.ExpenseGroupId, expenseDetail, claim.UserId, claim.EmployeeCode, userName);

                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "[{ControllerName}] - CreateExpenseTrack error ", _controllerName);
                return ResponseResult.Failure<CreateExpenseTrackResponseDto>("เกิดข้อผิดพลาดที่ระบบ กรุณาติดต่อ IT Support");
            }
        }
    }
}