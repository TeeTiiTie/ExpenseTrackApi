namespace ExpenseTrackApi.DTOs.Master
{
    public class CustomerDetailRequestDto
    {
        public string? ApplicationCode { get; set; }
        public string? SearchText { get; set; } // customerName, identificatiNo
    }
}