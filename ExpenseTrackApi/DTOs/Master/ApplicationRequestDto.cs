using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackApi.DTOs.Master
{
    public class ApplicationRequestDto : IValidatableObject
    {
        [Required]
        public string? SchoolYear { get; set; }

        public int? BranchId { get; set; }
        public string? SearchText { get; set; } // ระบุ ชื่อโรงเรียน/AppID อย่างน้อย 4 ตัวอักษร  AutoComplet

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                if (SearchText.Length < 4)
                    yield return new ValidationResult("ระบุ ชื่อโรงเรียน/AppID อย่างน้อย 4 ตัวอักษร");
            }
        }
    }
}