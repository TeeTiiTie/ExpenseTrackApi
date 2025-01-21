using ExpenseTrackApi.DTOs;
using ExpenseTrackApi.DTOs.ExpenseTrack;
using ExpenseTrackApi.Models;
using ExpenseTrackApi.Services.Auth;
using ExpenseTrackApi.Services.ExpenseTrack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExpenseTrackApi.Controllers
{
    [Route("api/expensetrack")]
    [ApiController]
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

        [HttpGet("expenses", Name = "GetExpenses")]
        public async Task<ServiceResponse<List<GetExpensesResponseDto>>> GetExpenses([FromQuery] GetExpensesRequestDto filter, [FromQuery] PaginationDto paginationDto, [FromQuery] QuerySortDto sortDto)
        {
            try
            {
                var (data, paginationResultDto) = await _services.GetExpenses(filter, paginationDto, sortDto);

                return ResponseResult.Success(data, paginationResultDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "[{ControllerName}] - GetExpenses error ", _controllerName);
                return ResponseResult.Failure<List<GetExpensesResponseDto>>("เกิดข้อผิดพลาดที่ระบบ กรุณาติดต่อ IT Support");
            }
        }
    }
}