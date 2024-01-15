using DATN_ACV_DEV.Model_DTO.Invoice;

namespace DATN_ACV_DEV.Model_DTO.Invoice_DTO
{
    public class EditInvoiceRequest : CreateInvoiceRequest
    {
        public Guid Id { get; set; }

    }
}
