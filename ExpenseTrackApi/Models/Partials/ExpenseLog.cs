﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackApi.Models
{
    public partial class ExpenseLog
    {
        public static ExpenseLog NewExpenseLog(Guid? expenseGroupId, string expenseDetail, int? userId, string userCode, string userName)
        {
            var log = new ExpenseLog
            {
                ExpenseLogId = Guid.NewGuid(),
                ExpenseGroupId = expenseGroupId,
                ExpenseTypeId = 2,
                ExpenseDetail = expenseDetail,
            };

            log.SetCreatedDate(userId,userCode,userName);

            return log;
        }

        public void SetCreatedDate(int? userId, string userCode, string userName)
        {
            CreatedDate = DateTime.Now;
            CreatedByUserId = userId;
            CreatedByCode = userCode;
            CreatedByName = userName;
            IsActive = true;
        }
    }
}