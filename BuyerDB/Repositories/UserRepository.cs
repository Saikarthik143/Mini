using System;
using System.Collections.Generic;
using System.Text;
using BuyerDB.Models;
using BuyerDB.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace BuyerDB.Repositories
{
  public  class UserRepository : IUserRepository
    {
        private readonly BuyerContext _context;
        public UserRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<Buyer> BuyerLogin(string userName, string password)
        {
            Buyer buyer = _context.Buyer.SingleOrDefault(e => e.Buyername == userName && e.Password == password);
            if (buyer.Buyername == userName && buyer.Password == password)
                return buyer;
            else
            {
                Console.WriteLine("not a valid");
                return buyer;
            }

        }

        public async Task<bool> BuyerRegistration(Buyer buyer)
        {
            _context.Add(buyer);
            var user = await _context.SaveChangesAsync();
            if (user > 0)
                return true;
            else
                return false;
        }

      
    }
}
