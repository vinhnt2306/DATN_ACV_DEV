﻿using Azure.Core;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Model_DTO.GHN_DTO;
using DATN_ACV_DEV.Model_DTO.Order_DTO;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace DATN_ACV_DEV.Utility
{
    public class Common
    {
        public static int _ApiTimeout { get; set; } = 120000; 
        public static GHNProvinceResponse GetLstProvince(GHNProvinceRequest req)
        {

            var client = new RestClient("https://online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/master-data/province";
            var Restreq = new RestRequest(apiEndPoint, Method.Get)
            {
                RequestFormat = DataFormat.Json
            };
            Restreq.AddHeader("token", req.token);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNProvinceResponse>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result;
        }
        public static GHNDistrictResponse GetLstDistric(GHNDistrictRequest req)
        {

            var client = new RestClient("https://online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/master-data/district";
            var Restreq = new RestRequest(apiEndPoint, Method.Get)
            {
                RequestFormat = DataFormat.Json
            };
            GHNDistrisReq ReqBody = new GHNDistrisReq()
            {
                province_id = req.provinceID
            };
            Restreq.AddHeader("token", req.token);
            Restreq.AddBody(ReqBody);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNDistrictResponse>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result;
        }
        public static GHNWardResponse GetLstWard(GHNWardRequest req)
        {

            var client = new RestClient("https://online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/master-data/ward";
            var Restreq = new RestRequest(apiEndPoint, Method.Get)
            {
                RequestFormat = DataFormat.Json
            };
            GHNWardReq ReqBody = new GHNWardReq()
            {
                district_id = req.districtID
            };
            Restreq.AddHeader("token", req.token);
            Restreq.AddBody(ReqBody);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNWardResponse>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result;
        }
        public static GHNServiceResponse GetLstService(GHNServiceRequest req)
        {

            var client = new RestClient("https://online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/v2/shipping-order/available-services";
            var Restreq = new RestRequest(apiEndPoint, Method.Get)
            {
                RequestFormat = DataFormat.Json
            };
            GHNServiceReq ReqBody = new GHNServiceReq()
            {
                shop_id = req.shopID,
                from_district = req.fromDistrictID,
                to_district = req.toDistrictID,
            };
            Restreq.AddHeader("token", req.token);
            Restreq.AddBody(ReqBody);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNServiceResponse>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result;
        }
        public static decimal GetFee(string token, GHNFeeRequest req)
        {
            var client = new RestClient("https://online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/v2/shipping-order/fee";
            var Restreq = new RestRequest(apiEndPoint, Method.Get)
            {
                RequestFormat = DataFormat.Json
            };
            Restreq.AddHeader("token", token);
            Restreq.AddHeader("shop_id", Utility.SHOP_ID_SHIP);
            Restreq.AddBody(req);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNFeeResponse>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result.data.total;
        }
        public static CalculateVoucher CalculateDiscount(decimal? totalAmount, TbVoucher voucher)
        {
            CalculateVoucher model = new CalculateVoucher();
            if (voucher.Type == Utility.VOUCHER_DISCOUNT)
            {
                if (voucher.Unit == "%")
                {
                    model.DiscountVoucher = (totalAmount * voucher.Discount) / 100;
                }
                if (voucher.Unit.ToUpper() == "VND")
                {
                    model.DiscountVoucher = voucher.Discount;
                }
            }
            if (voucher.Type == Utility.VOUCHER_FREESHIP)
            {
                model.DiscountShipping = voucher.Discount;

            }
            return model;
        }
        public static GHNCreateOrderDTO CreateOderGHN(RequestCreateOrderGHN req)
        {

            var client = new RestClient("https://dev-online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/v2/shipping-order/create";
            var Restreq = new RestRequest(apiEndPoint, Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            Restreq.AddHeader("Content-Type", "application/json");
            Restreq.AddHeader("ShopId", Utility.SHOP_ID);
            Restreq.AddHeader("Token", Utility.tokenGHN);
            Restreq.AddBody(req);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNCreateOrderDTO>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result;
        }
        public static GHNInfoOrderResponse InfoOrderGHN( GHNInfoOrderRequest req)
        {
            var client = new RestClient("https://dev-online-gateway.ghn.vn/shiip/");
            string apiEndPoint = "public-api/v2/shipping-order/detail";
            var Restreq = new RestRequest(apiEndPoint, Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            Restreq.AddHeader("Content-Type", "application/json");
            Restreq.AddHeader("Token", Utility.tokenGHN);
            Restreq.AddBody(req);
            var res = client.Execute(Restreq);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("URL_ERROR_CONNECT");
            }
            var Result = JsonConvert.DeserializeObject<GHNInfoOrderResponse>(res.Content, new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore

            });
            return Result;
        }
    }
}
