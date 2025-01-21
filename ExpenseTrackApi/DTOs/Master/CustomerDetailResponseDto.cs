namespace ExpenseTrackApi.DTOs.Master
{
    public class CustomerDetailResponseDto
    {
        public string? CustomerCode { get; set; } // CDxxxxx
        public string? CustomerName { get; set; } // {Title}{FirstName} {LastName}
    }
}