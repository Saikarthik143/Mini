using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Repository;
using UserService.Models;
using Microsoft.Extensions.Logging;
using UserService.Extensions;


namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserRepository _repo;
        private readonly ILogger<UserController> _logger;
        public UserController(IuserRepository repo ,ILogger<UserController> logger)

        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        [Route("Login/{uname}/{pwd}")]
        public IActionResult Login(string uname,string pwd)
        {
            try
            {
                _logger.LogInformation("user login");
                Buyer buyer = _repo.BuyerLogin(uname, pwd);
               
                return Ok(buyer);
            }
            catch (MyAppException e)
            {
                throw e;
            }
        }
        [HttpPost]
        [Route("AddBuyer")]
        public IActionResult Registration(Buyer buyer)
        {
            try
            {
                _repo.BuyerRegistration(buyer);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }

        }
       
    }
}