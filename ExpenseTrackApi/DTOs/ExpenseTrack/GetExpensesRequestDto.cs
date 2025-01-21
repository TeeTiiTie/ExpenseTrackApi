using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public class GetExpensesRequestDto
    {
        [Required]
        public DateTime? CreatedDateFrom { get; set; }

        [Required]
        public DateTime? CreatedDateTo { get; set; }

        public int? BranchId { get; set; }
        public int? ExpenseStatusId { get; set; }
        public string? SearchText { get; set; }
    }
}