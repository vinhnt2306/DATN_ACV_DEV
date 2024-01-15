namespace DATN_ACV_DEV.Model_DTO.Order_DTO
{
    public class GetListOrderByCustomerResponse
    {
        public GetListOrderByCustomerResponse()
        {
            products = new List<OrderDetailProduct>();
        }
        public Guid id { get; set; }
        public string? orderCode { get; set; }
        public string? nameUser { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public decimal? amountShip { get; set; }
        public decimal? totalProduct { get; set; }
        public decimal? totalAmount { get; set; }
        public int? status { get; set; }
        public List<OrderDetailProduct> products { get; set; }
    }
}
