using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuyerService.Manager;
using BuyerDB.Entity;
using BuyerDB.Models;
using UserService.Extensions;

namespace BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerManager _buyerManager;
        public BuyerController(IBuyerManager iBuyerManager)
        {
            _buyerManager = iBuyerManager;
        }
        [HttpPost]
        [Route("buyerProfile")]
        public async Task<IActionResult> EditBuyerProfile(Buyer buyer)
        {
            try
            {
                return Ok(await _buyerManager.EditProfile(buyer));
            }
            catch (MyAppException ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        [Route("buyerProfile/{bid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuyerProfile(string buyerId)
        {
            try
            {
                Buyer buyer = await _buyerManager.GetBuyerProfile(buyerId);

                return Ok(buyer);
            }
            catch (MyAppException ex)
            {
                throw ex;
            }
        }
    }
}
   