using AutoMapper;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.FileBase;
using DATN_ACV_DEV.Model_DTO.Customer_DTO;
using DATN_ACV_DEV.Model_DTO.Invoice_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DATN_ACV_DEV.Controllers.Invoice
{
    [Route("api/GetListInvoice")]
    [ApiController]
    public class GetListInvoiceController : ControllerBase, IBaseController<GetListInvoiceRequest, GetListInvoicecResponse>
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private GetListInvoiceRequest _request;
        private BaseResponse<GetListInvoicecResponse> _res;
        private GetListInvoicecResponse _response;
        private string _apiCode = "GetListInvoice";
        public GetListInvoiceController(DBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _res = new BaseResponse<GetListInvoicecResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null,
            };
            _response = new GetListInvoicecResponse();
        }
        public void AccessDatabase()
        {
            List<InvoiceDTO> LstInvoice = new List<InvoiceDTO>();
            var model = _context.TbInvoices.Where(c => (!string.IsNullOrEmpty(_request.Unit) ? c.Unit.Contains(_request.Unit) : true)
                        && (c.InputDate.Date == _request.InputDate)
                        && (_request.ProductId.HasValue ? c.ProductId == _request.ProductId : true)
                        && (_request.SupplierId.HasValue ? c.SupplierId == _request.SupplierId : true)
                        ).OrderByDescending(d => d.CreateDate);
            _response.TotalCount = model.Count();
            var query = _mapper.Map<List<InvoiceDTO>>(model);
            if (_request.Limit == null)
            {
                LstInvoice = query.Skip(_request.OffSet.Value).Take(Utility.Utility.LimitDefault).ToList();
            }
            else
            {
                LstInvoice = query.Skip(_request.OffSet.Value).Take(_request.Limit.Value).ToList();
            }
            _response.LstInvoice = LstInvoice;
            _res.Data = _response;
        }

        public void CheckAuthorization()
        {
            throw new NotImplementedException();
        }
        public void GenerateObjects()
        {
            throw new NotImplementedException();
        }

        public void PreValidation()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Process")]
        public BaseResponse<GetListInvoicecResponse> Process(GetListInvoiceRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                //PreValidation();
                //GenerateObjects();
                //PostValidation();
                AccessDatabase();
            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }
            return _res;
        }
    }
}
