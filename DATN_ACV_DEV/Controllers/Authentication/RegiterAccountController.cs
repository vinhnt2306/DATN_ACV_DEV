using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.FileBase;
using DATN_ACV_DEV.Model_DTO.Category_DTO;
using DATN_ACV_DEV.Model_DTO.Image_DTO;
using DATN_ACV_DEV.Model_DTO.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DATN_ACV_DEV.Controllers.Authentication
{
    [Route("api/RegiterAccount")]
    [ApiController]
    public class RegiterAccountController : ControllerBase, IBaseController<LoginRequest, LoginResponse>
    {
        public IConfiguration _Configuration { get; }
        private readonly DBContext _context;
        private LoginRequest _request;
        private BaseResponse<LoginResponse> _res;
        private LoginResponse _response;
        private string _apiCode = "RegiterAccount";
        private TbUser _User;
        public RegiterAccountController(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _res = new BaseResponse<LoginResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new LoginResponse();
            _Configuration = configuration;

        }
        public void AccessDatabase()
        {
            throw new NotImplementedException();
        }

        public void CheckAuthorization()
        {         

            _res.Data = _response;
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
        public BaseResponse<LoginResponse> Process(LoginRequest request)
        {
            try
            {
                _request = request;
                CheckAuthorization();
                //PreValidation();
                //GenerateObjects();
                //PostValidation();
                //AccessDatabase();
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
