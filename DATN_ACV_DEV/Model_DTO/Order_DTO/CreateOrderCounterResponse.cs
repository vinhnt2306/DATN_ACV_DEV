namespace DATN_ACV_DEV.Model_DTO.Order_DTO
{
    public class CreateOrderCounterResponse
    {
        public CreateOrderCounterResponse()
        {
            products = new List<OrderProduct>();
        }
        public List<OrderProduct> products { get; set; }
        public decimal? totalAmount { get; set; }
        public decimal? totalAmountDiscount { get; set; }
        public string? paymentMethod { get; set; }
        public List<string>? voucherCode { get; set; }
        public List<Guid>? voucherId { get; set; }
        public List<Guid>? cartDetailId { get; set; }

    }
}
