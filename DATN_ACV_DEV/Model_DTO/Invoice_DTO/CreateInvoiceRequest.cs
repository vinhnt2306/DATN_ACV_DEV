namespace DATN_ACV_DEV.Model_DTO.Invoice
{
    public class CreateInvoiceRequest
    {
        public Guid Id { get; set; }

        public string Unit { get; set; }

        public int QuantityProduct { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime InputDate { get; set; }

        public Guid? UpdateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid ProductId { get; set; }

        public Guid SupplierId { get; set; }
    }
}
