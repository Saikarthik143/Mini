using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.Extensions;
using UserService.Manager;
using BuyerDB.Models;
using BuyerDB.Entity;
using BuyerDB.Repositories;


namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(IUserRepository repo ,ILogger<UserController> logger,IUserManager userManager)

        {
            _userManager = userManager;
            _repo = repo;
            _logger = logger;
        }
        /// <summary>
        /// Login Buyer
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        [HttpGet]
        [Route("Login/{uname}/{pwd}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(string uname,string pwd)
        {
            try
            {
                _logger.LogInformation("user login");
                Buyer buyer = await _userManager.BuyerLogin(uname, pwd);
               
                return Ok(buyer);
            }
            catch (MyAppException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Register buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBuyer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuyerRegister(Buyer buyer)
        {
            _logger.LogInformation("user Register");
            if (buyer == null)
                return BadRequest("there is no buyer");
            if (!ModelState.IsValid)
                return BadRequest();
            await _userManager.BuyerRegistration(buyer);
            _logger.LogInformation("Successfully Registered");
            return Ok();
        }
        /// <summary>
        /// Register buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBuyer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Registration(Buyer buyer)
        {
            try
            {
                _logger.LogInformation("Registration");

                return Ok(await _userManager.BuyerRegistration(buyer));
               
            }
            catch (Exception e)
            {
                throw e;
            }

        }
       
    }
}