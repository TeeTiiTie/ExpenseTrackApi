using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public class GetExpenseLogRequestDto
    {
        [Required]
        public Guid? ExpenseGroupId { get; set; }
    }
}