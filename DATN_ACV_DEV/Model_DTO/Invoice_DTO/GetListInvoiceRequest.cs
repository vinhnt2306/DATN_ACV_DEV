using DATN_ACV_DEV.FileBase;

namespace DATN_ACV_DEV.Model_DTO.Invoice_DTO
{
    public class GetListInvoiceRequest : BaseRequest
    {
        public string? Unit { get; set; } = null!;

        public int? QuantityProduct { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? InputDate { get; set; } = DateTime.Now.Date;

        public Guid? ProductId { get; set; }

        public Guid? SupplierId { get; set; }
    }
}
