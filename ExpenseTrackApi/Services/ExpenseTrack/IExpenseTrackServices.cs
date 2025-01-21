﻿using ExpenseTrackApi.DTOs.ExpenseTrack;
using ExpenseTrackApi.Models;

namespace ExpenseTrackApi.Services.ExpenseTrack
{
    public interface IExpenseTrackServices
    {
        Task InsertExpenseLog(Guid? expenseGroupId, string expenseDetail, int? userId, string userCode, string userName);
        Task<ServiceResponse<CreateExpenseTrackResponseDto>> InsertExpenseTrack(CreateExpenseTrackRequestDto input, int? userId, string userCode, string userName);
    }
}