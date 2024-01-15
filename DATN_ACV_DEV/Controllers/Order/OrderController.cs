using AutoMapper;
using DATN_ACV_DEV.Entity;
using DATN_ACV_DEV.Model_DTO.GHN_DTO;
using DATN_ACV_DEV.Model_DTO.Order_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DATN_ACV_DEV.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public OrderController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        [Route("getOrdersByItemId")]
        public IActionResult GetOrdersByItemId(Guid uId)
        {
            try
            {
                var order = _context.TbOrders.FirstOrDefault(c => c.Id == uId);
                var item = _mapper.Map<GetListOrderByCustomerResponse>(order);

                var product= from _repo in _context.TbOrders.ToList().Where(x=>x.Id==uId)
                             join orderDetail in _context.TbOrderDetails on _repo.Id equals orderDetail.OrderId
                             join prod in _context.TbProducts on orderDetail.ProductId equals prod.Id
                             join img in _context.TbImages on prod.ImageId equals img.Id
                             select new
                             {
                                 _repo, orderDetail, prod,
                                 img
                             };
                var ad = _context.TbAddressDeliveries.FirstOrDefault(x => x.Id == order.AddressDeliveryId);
                if (ad != null) {
                    item.address = ad.WardName + ", " + ad.DistrictName + ", " + ad.ProvinceName;
                    item.nameUser= ad.WardName + ", " + ad.DistrictName + ", " + ad.ProvinceName;
                    item.phoneNumber= ad.WardName + ", " + ad.DistrictName + ", " + ad.ProvinceName;
                }
                item.products = product.ToList().Select(t =>
                {
                    var ouput = new OrderDetailProduct();
                    ouput.price = t.prod.Price;
                    ouput.productName = t.prod.Name;
                    if (t.img != null) {
                        ouput.url = t.img.Url;
                        }
                    ouput.quantity=t.prod.Quantity;
                    return ouput;
                }).ToList();
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTrangThai")]
        public IActionResult UpdateTrangThai(Guid uId, int status, Guid idBoss)
        {
            try
            {
                var listGet = _context.TbOrderDetails.Where(x => x.OrderId == uId);
                var order=_context.TbOrders.FirstOrDefault(x=>x.Id== uId);
                var res = _mapper.Map<GetListOrderByCustomerResponse>(order);

                var product = from _repo in _context.TbOrders.ToList().Where(x => x.Id == uId)
                              join orderDetail in _context.TbOrderDetails on _repo.Id equals orderDetail.OrderId
                              join prod in _context.TbProducts on orderDetail.ProductId equals prod.Id
                              select new
                              {
                                  _repo,
                                  orderDetail,
                                  prod
                              };

                if (order != null) {
                    order.Status = status;
                    _context.TbOrders.Update(order);
                    _context.SaveChanges();
                    var listReturn = new List<OrderDetailProduct>();
                    if (listGet != null && listGet.Any())
                    {
                        foreach (var item in listGet)
                        {
                            var productItem = _context.TbProducts.FirstOrDefault(s => s.Id == item.ProductId);
                            if (productItem != null)
                            {
                                if (status == 2)
                                {
                                    productItem.Quantity = productItem.Quantity + item.Quantity;
                                    _context.TbProducts.Update(productItem);
                                    _context.SaveChanges();
                                }
                                if (status == 1)
                                {
                                    //productItem.Stock = productItem.Stock - item.Quantity;
                                    //_context.ShoesVariants.Update(productItem);
                                    //_context.SaveChanges();
                                }
                                else if (status == 7)
                                {
                                    productItem.Quantity = productItem.Quantity + item.Quantity;
                                    _context.TbProducts.Update(productItem);
                                    _context.SaveChanges();
                                }
                                else if (status == 6)
                                {
                                    productItem.Quantity = productItem.Quantity + item.Quantity;
                                    _context.TbProducts.Update(productItem);
                                    _context.SaveChanges();
                                }
                                else if (status == 8)
                                {
                                    productItem.Quantity = productItem.Quantity + item.Quantity;
                                    _context.TbProducts.Update(productItem);
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    res.products = product.ToList().Select(t =>
                    {
                        var ouput = new OrderDetailProduct();
                        ouput.price = t.prod.Price;
                        ouput.productName = t.prod.Name;
                        ouput.quantity = t.prod.Quantity;
                        ouput.url = _context.TbImages.FirstOrDefault(c => c.ProductId == t.prod.Id)?.Url;
                        return ouput;
                    }).ToList();
                    var text = "";
                    var body = "";
                    if (status == 1)
                    {
                        text = "đã phê duyệt đơn hàng";
                    }
                    else if (status == 2)
                    {
                        text = "đã từ chối đơn hàng";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 6)
                    {
                        text = "đã hủy đơn hàng";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 3)
                    {
                        text = "Đơn hàng đang giao";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 4)
                    {
                        text = "Đơn hàng đang trên đường giao tới bạn";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 5)
                    {
                        text = "Đơn hàng đang trên đường giao tới bạn";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 5)
                    {
                        text = "đã nhận hàng";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 7)
                    {
                        text = "từ chối nhận hàng";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    else if (status == 8)
                    {
                        text = "Khách hàng không nhận hàng";
                        var voucherUserLog = _context.TbOrderHistories.FirstOrDefault(c => c.OrderId == uId);
                        if (voucherUserLog != null)
                        {
                            _context.TbOrderHistories.Remove(voucherUserLog);
                            _context.SaveChanges();
                        }
                    }
                    var x = new TbOrderHistories()
                    {
                        IdKhachHang = order.AccountId,
                        OrderId = uId,
                        LogTime = DateTime.Now,
                        Message = text
                    };
                    if (idBoss != null)
                    {
                        x.IdBoss = idBoss;
                    }
                    if (status == 3 || status == 4)
                    {
                        x.IdKhachHang = null;
                        x.IdBoss = null;
                    }
                    _context.TbOrderHistories.Add(x);
                    _context.SaveChanges();
                    return Ok(res);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("GetUseLog")]

        public IActionResult GetUseLog(Guid orderId)
        {
            try
            {
                var res = _context.TbOrderHistories.Where(x => x.OrderId == orderId).ToList();

                if (res.Any())
                {
                    var item = res.Select(t =>
                    {
                        var output = new OrderLogResponse();

                        if (t.IdBoss != null)
                        {
                            output.TenBoss = _context.TbUsers.FirstOrDefault(x => x.Id == t.IdBoss)?.FullName;
                        }
                        if (t.IdKhachHang != null)
                        {
                            if (_context.TbAccounts.FirstOrDefault(x => x.Id == t.IdKhachHang).CustomerId != null) {
                                output.TenKhachHang = _context.TbCustomers.FirstOrDefault(x => x.Id == _context.TbAccounts.FirstOrDefault(x => x.Id == t.IdKhachHang).CustomerId).Name;
                            }
                            
                        }
                        output.OrderId = orderId;
                        output.Message = t.Message;
                        output.LogTime = t.LogTime;
                        output.Id = t.Id;
                        return output;
                    });
                    return Ok(item);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
    public class OrderLogResponse
    {

        public int Id { get; set; }
        public Guid OrderId { get; set; }

        public Guid? IdKhachHang { get; set; }
        public string? TenKhachHang { get; set; }
        public string? TenBoss { get; set; }

        public Guid? IdBoss { get; set; }

        public string? Message { get; set; }
        public DateTime LogTime { get; set; }


    }

}
