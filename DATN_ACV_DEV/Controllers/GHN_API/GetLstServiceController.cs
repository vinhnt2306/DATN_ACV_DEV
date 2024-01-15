﻿using AutoMapper;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.FileBase;
using DATN_ACV_DEV.Model_DTO.Category_DTO;
using DATN_ACV_DEV.Model_DTO.GHN_DTO;
using DATN_ACV_DEV.Model_DTO.HomePage;
using DATN_ACV_DEV.Model_DTO.Image_DTO;
using DATN_ACV_DEV.Model_DTO.Product_DTO;
using DATN_ACV_DEV.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN_ACV_DEV.Controllers
{
    [Route("api/GetLstService")]
    [ApiController]
    public class GetLstServiceController : ControllerBase, IBaseController<GHNServiceRequest, GHNServiceResponse> 
    {
        private readonly DBContext _context;
        private GHNServiceRequest _request;
        private BaseResponse<GHNServiceResponse> _res;
        private GHNServiceResponse _response;
        private string _apiCode = "GetLstService";
        private TbImage _Image;
        public GetLstServiceController(DBContext context)
        {
            _context = context;
            _res = new BaseResponse<GHNServiceResponse>()
            {
                Status = StatusCodes.Status200OK.ToString(),
                Data = null
            };
            _response = new GHNServiceResponse();
        }

        public void AccessDatabase()
        {
            _response = Common.GetLstService(_request);
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
        public BaseResponse<GHNServiceResponse> Process(GHNServiceRequest request)
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
