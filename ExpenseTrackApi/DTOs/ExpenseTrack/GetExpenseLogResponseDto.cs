using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public class GetExpenseLogResponseDto
    {
        public int? ExpenseTypeId { get; set; }
        public string? ExpenseDetail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }
        public string? CreatedByCode { get; set; }
        public string? CreatedByName { get; set; }
    }
}