namespace DATN_ACV_DEV.Model_DTO.Invoice_DTO
{
    public class GetListInvoicecResponse
    {
        public GetListInvoicecResponse()
        {
            LstInvoice = new List<InvoiceDTO> { };

        }
        public List<InvoiceDTO> LstInvoice { get; set; }
        public int TotalCount { get; set; }
    }
    public class InvoiceDTO
    {
        public Guid Id { get; set; }
        public string Unit { get; set; } = null!;
        public int QuantityProduct { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime InputDate { get; set; }
        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
