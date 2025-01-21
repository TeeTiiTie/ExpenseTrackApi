namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public class CreateExpenseTrackResponseDto
    {
        public Guid? ExpenseGroupId { get; set; }
        public string? ExpenseGroupCode { get; set; }
        public string? DocumentCode { get; set; }
    }
}