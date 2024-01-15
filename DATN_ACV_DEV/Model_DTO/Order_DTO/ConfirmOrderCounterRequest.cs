﻿using DATN_ACV_DEV.FileBase;

namespace DATN_ACV_DEV.Model_DTO.Order_DTO
{
    public class ConfirmOrderCounterRequest : BaseRequest
    {
        public Guid paymentMethodId { get; set; }
        public List<Guid>? voucherID { get; set; }
        public List<string>? voucherCode { get; set; }
        public string? description { get; set; }
        public List<Guid> cartDetailId { get; set; }
        public decimal? totalAmountDiscount { get; set; }
        public decimal? totalAmount { get; set; }
        public string? customerName { get; set; }
        public string? phoneNumber { get; set; }
    }
}
