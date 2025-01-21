using AutoMapper;
using ExpenseTrack.Data;
using ExpenseTrack.Models;
using ExpenseTrackApi.DTOs.ExpenseTrack;
using ExpenseTrackApi.Models;
using Serilog;

namespace ExpenseTrackApi.Services.ExpenseTrack
{
    public class ExpenseTrackServices : IExpenseTrackServices
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly Serilog.ILogger? _logger;

        public ExpenseTrackServices(AppDBContext dBContext, IMapper mapper, Serilog.ILogger? logger = null)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _logger = _logger = logger?.ForContext("ServiceName", _serviceName) ?? Log.ForContext("ServiceName", _serviceName);
        }

        private const string _serviceName = nameof(ExpenseTrackServices);

        public async Task<ServiceResponse<CreateExpenseTrackResponseDto>> InsertExpenseTrack(CreateExpenseTrackRequestDto input, int? userId, string userCode, string userName)
        {
            OutputParameter<string> groupCode = new OutputParameter<string>();
            await _dBContext.Procedures.usp_GenerateCodeAsync("EXP", 6, groupCode);

            var expenseGroup = ExpenseGroup.NewExpenseGroup(input, groupCode.ToString(), userId, userCode, userName);

            List<ExpenseItem> expenseItems = new();

            foreach (var i in input.CreateExpenseTrackDetails)
            {
                var expenseItem = ExpenseItem.NewExpenseItem(i, expenseGroup.ExpenseGroupId);
                expenseItems.Add(expenseItem);
            }

            _dBContext.Add(expenseGroup);
            _dBContext.AddRange(expenseItems);
            await _dBContext.SaveChangesAsync();
            _logger.Information("[{serviceName}] - Insert table ExpenseGroup and ExpenseItem successful ExpenseGroupId: {groupId}", _serviceName, expenseGroup.ExpenseGroupId);

            var response = new CreateExpenseTrackResponseDto
            {
                ExpenseGroupId = expenseGroup.ExpenseGroupId,
                ExpenseGroupCode = expenseGroup.ExpenseGroupCode,
                DocumentCode = expenseGroup.DocumentCode
            };

            return ResponseResult.Success(response);
        }

        public async Task InsertExpenseLog(Guid? expenseGroupId, string expenseDetail, int? userId, string userCode, string userName)
        {
            ExpenseLog expendLog = ExpenseLog.NewExpenseLog(expenseGroupId, expenseDetail, userId, userCode, userName);

            _dBContext.Add(expendLog);
            await _dBContext.SaveChangesAsync();
            _logger.Information("[{serviceName}] - Insert table ExpenseLog successful ExpenseLogId: {ExpenseLogId}", _serviceName, expendLog.ExpenseLogId);
        }
    }
}