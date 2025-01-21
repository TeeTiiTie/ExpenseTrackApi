using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackApi.DTOs.ExpenseTrack
{
    public class CreateExpenseTrackRequestDto
    {
        [Required]
        public string? ApplicationCode { get; set; }

        [Required]
        public string? ShcoolYear { get; set; }

        [Required]
        public int? BranchId { get; set; }

        [Required]
        public string? BranchName { get; set; }

        [Required]
        public string? ShcoolName { get; set; }

        [Required]
        public string? PayeeAccountName { get; set; }

        [Required]
        public int? PayeeBankId { get; set; }

        [Required]
        public string? PayeeBankName { get; set; }

        [Required]
        public string? PayeeAccountNumber { get; set; }

        [Required]
        public int? ServiceBranchId { get; set; }

        [Required]
        public string? ServiceBranchName { get; set; }

        [Required]
        public int? ServiceByUserId { get; set; }

        [Required]
        public string? ServiceByCode { get; set; }

        [Required]
        public string? ServiceByName { get; set; }

        [Required]
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
        [Required]
        public string? CustomerCode { get; set; }

        [Required]
        public string? CustomerName { get; set; }

        public string? LevelRoom { get; set; }
        public string? IdentificatiNo { get; set; }
        public string? CustomerTypeId { get; set; }
        public string? CustomerTypeName { get; set; }
        public string? StatusId { get; set; }
        public string? StatusName { get; set; }

        [Required]
        public decimal? Amount { get; set; }
    }
}