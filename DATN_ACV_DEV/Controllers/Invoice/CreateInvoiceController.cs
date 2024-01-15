using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.FileBase;
using DATN_ACV_DEV.Model_DTO.Customer_DTO;
using DATN_ACV_DEV.Model_DTO.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace DATN_ACV_DEV.Controllers.Invoice
{
    [Route("api/CreateInvoice")]
    [ApiController]
    public class CreateInvoiceController : ControllerBase, IBaseController<CreateInvoiceRequest, CreateInvoiceResponse>
    {
        private readonly DBContext _context;
        private CreateInvoiceRequest _request;
        private BaseResponse<CreateInvoiceResponse> _res;
        private CreateInvoiceResponse _response;
        private TbInvoice _Invoice;
        private TbProduct _Product;
        public CreateInvoiceController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<CreateInvoiceResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new CreateInvoiceResponse();
        }
        public void AccessDatabase()
        {
            _context.Add(_Invoice);
            _context.SaveChanges();
            _response.Message = "Thêm mới thành công !!!";
            _res.Data = _response;
            if (_res.Data.Message == "Thêm mới thành công !!!")
            {
                _Product = _context.TbProducts.Where(c => c.Id == _Invoice.ProductId).FirstOrDefault();
                if (_Product != null)
                {
                    _Product.Quantity = _Product.Quantity + _Invoice.QuantityProduct;
                    _Product.UpdateDate = DateTime.Now;
                }
                _context.SaveChanges();
            }
        }

        public void CheckAuthorization()
        {
            throw new NotImplementedException();
        }

        public void GenerateObjects()
        {
            _Invoice = new TbInvoice()
            {
                Id = Guid.NewGuid(),
                Unit = _request.Unit,
                QuantityProduct = _request.QuantityProduct,
                IsDelete = false,
                InputDate = DateTime.Now,
                CreateBy = Guid.Parse("9a8d99e6-cb67-4716-af99-1de3e35ba993"),
                CreateDate = DateTime.Now,
                ProductId = _request.ProductId,
                SupplierId = _request.SupplierId
            };
        }

        public void PreValidation()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Process")]
        public BaseResponse<CreateInvoiceResponse> Process(CreateInvoiceRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                //PreValidation(); // validate dữ liệu 
                GenerateObjects(); // Gán dữ liệu 
                AccessDatabase(); // Lưu xuống DB 

            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }
            return _res;
        }
    }
}
