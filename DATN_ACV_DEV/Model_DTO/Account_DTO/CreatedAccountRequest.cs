namespace DATN_ACV_DEV.Model_DTO.Account_DTO
{
    public class CreatedAccountRequest 
    {
        public string AccountCode { get; set; } 

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public Guid CustomerId { get; set; }
    }
}
