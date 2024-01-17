using Azure;
using DATN_ACV_DEV.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DATN_ACV_DEV.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DBContext _context;
        public RegisterController(DBContext context)
        {
            _context = context;    
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model) {

            var user=_context.TbAccounts.FirstOrDefault(x=>x.PhoneNumber==model.PhoneNumber);
            if (user != null) {
                return StatusCode(StatusCodes.Status500InternalServerError, new  { Status = "Error", Message = "Email này đã được đăng ký vui lòng chọn email khác" });
            }
            var id = new Guid();
            var profile = new TbCustomer()
            {
                Id = id,
                Name = model.FullName
            };
            var account = new TbAccount()
            {
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Id = new Guid(),
                CustomerId=id,
            };
            _context.TbCustomers.Add(profile);
            _context.TbAccounts.Add(account);
            _context.SaveChanges();
            return Ok(new 
            {
                Status = "Success",
                Message = "User created successfully!",
            });
        }
    }


    public class RegisterModel
    {

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? FullName { get; set; }

    }
}
