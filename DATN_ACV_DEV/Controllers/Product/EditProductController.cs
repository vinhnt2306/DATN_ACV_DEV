using AutoMapper;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.FileBase;
using DATN_ACV_DEV.Model_DTO.HomePage;
using DATN_ACV_DEV.Model_DTO.Product_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace DATN_ACV_DEV.Controllers
{
    [Route("api/EditProduct")]
    [ApiController]
    public class EditProductController : ControllerBase, IBaseController<EditProductRequest, EditProductResponse>
    {
        private readonly DBContext _context;
        private EditProductRequest _request;
        private BaseResponse<EditProductResponse> _res;
        private EditProductResponse _response;
        private string _apiCode = "EditProduct";
        private TbProduct _Produst;
        public EditProductController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<EditProductResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new EditProductResponse();
        }

        public void AccessDatabase()
        {
            _context.SaveChanges();
            _response.ID = _Produst.Id;
            _res.Data = _response;
        }

        public void CheckAuthorization()
        {
            throw new NotImplementedException();
        }

        public void GenerateObjects()
        {
            try
            {
                _Produst = _context.TbProducts.Where(p => p.Id == _request.ID && p.IsDelete == false).FirstOrDefault();
                if (_Produst != null)
                {
                    _Produst.Name = _request.Name;
                    _Produst.Code = _request.Code;
                    _Produst.Price = _request.Price;
                    _Produst.Status = _request.Status;
                    _Produst.Quantity = _request.Quantity;
                    _Produst.Description = _request.Description;
                    _Produst.PriceNet = _request.PriceNet;
                    if (_request.UrlImage != null)
                    {
                        var iamge = _context.TbImages.FirstOrDefault(x => x.Id == _Produst.ImageId);
                        iamge.Url = _request.UrlImage[0];
                        _context.TbImages.Update(iamge);
                        _context.SaveChanges();
                    }
                    _Produst.CategoryId = _request.CategoryId;
                    _Produst.UpdateBy = Guid.Parse("9a8d99e6-cb67-4716-af99-1de3e35ba993");//Guid của 1 tài khoản có trong DB
                    _Produst.UpdateDate = DateTime.Now; // Ngày hiện tại 
                }
            }
            catch (Exception)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
            }

        }

        public void PreValidation()
        {
            // Code không được trùng nhau
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("Process")]
        public BaseResponse<EditProductResponse> Process(EditProductRequest request)
        {
            try
            {
                _request = request;
                //CheckAuthorization();
                //PreValidation();
                GenerateObjects();
                //PostValidation();
                AccessDatabase();
            }
            catch (ACV_Exception ex)
            {
                _res.Status = StatusCodes.Status400BadRequest.ToString();
                _res.Messages = ex.Messages;
            }
            catch (System.Exception ex)
            {
                _res.Status = StatusCodes.Status500InternalServerError.ToString();
                _res.Messages.Add(Message.CreateErrorMessage(_apiCode, _res.Status, ex.Message, string.Empty));
            }
            return _res;

        }
    }
}
