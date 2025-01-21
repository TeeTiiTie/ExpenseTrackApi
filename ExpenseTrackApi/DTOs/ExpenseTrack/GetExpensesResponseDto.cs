namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public partial class GetExpensesResponseDto
    {
        public Guid? ExpenseGroupId { get; set; }
        public string? ExpenseGroupCode { get; set; }
        public string? ApplicationCode { get; set; }
        public string? ShcoolName { get; set; }
        public string? ServicedBy { get; set; }
        public string? CreatedDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TransferAmount { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? TransferRemark { get; set; }
        public int? ExpenseStatusId { get; set; }
        public string? ExpenseStatusName { get; set; }
        public string? CancelledRemark { get; set; }
    }
}