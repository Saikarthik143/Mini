using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuyerDB.Entity;
using BuyerDB.Models;
using UserService.Extensions;

namespace BuyerDB.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly BuyerContext _context;
        public BuyerRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<bool> EditProfile(Buyer buyer)
        {
            _context.Update(buyer);
            var user = await _context.SaveChangesAsync();
            if (user > 0)
                return true;
            else
                return false;
        }

        public async Task<Buyer> GetBuyerProfile(string buyerId)
        {
            try
            {
                Buyer buyer = await _context.Buyer.FindAsync(buyerId);
                return buyer;
            }
            catch(MyAppException e)
            {
                throw e;
            }
        }
    }
}
