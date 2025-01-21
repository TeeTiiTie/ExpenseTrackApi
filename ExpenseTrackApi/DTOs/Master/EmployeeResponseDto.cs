namespace ExpenseTrackApi.DTOs.Master
{
    public class EmployeeResponseDto
    {
        public int? UserId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; } //{FirstName} {LastName}
        public string? LevelRoom { get; set; }
        public string? IdentificationNo { get; set; }
        public int? CustomerTypeId { get; set; }
        public string? CustomerTypeName { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
    }
}