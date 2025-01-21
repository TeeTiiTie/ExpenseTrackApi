using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public class CreateExpenseTrackRequestDto
    {
        public string? ApplicationCode { get; set; }
        public string? ShcoolYear { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? ShcoolName { get; set; }
        public string? PayeeAccountName { get; set; }
        public int? PayeeBankId { get; set; }
        public string? PayeeBankName { get; set; }
        public string? PayeeAccountNumber { get; set; }
        public int? ServiceBranchId { get; set; }
        public string? ServiceBranchName { get; set; }
        public int? ServiceByUserId { get; set; }
        public string? ServiceByCode { get; set; }
        public string? ServiceByName { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? DocumentCode { get; set; }
        public Guid? DocumentId { get; set; }
        public int? ZebraId { get; set; }
        public string? ZebraName { get; set; }
        public int? ReceiveDocTypeId { get; set; }
        public string? ReceiveDocTypeName { get; set; }
        public List<CreateExpenseTrackDetail>? CreateExpenseTrackDetails { get; set; }
    }

    public class CreateExpenseTrackDetail
    {
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
        public string? LevelRoom { get; set; }
        public string? IdentificatiNo { get; set; }
        public string? CustomerTypeId { get; set; }
        public string? CustomerTypeName { get; set; }
        public string? StatusId { get; set; }
        public string? StatusName { get; set; }
        public decimal? Amount { get; set; }
    }
}