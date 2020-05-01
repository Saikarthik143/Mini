using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository : IuserRepository
    {
        private readonly BuyerContext _context;
        public UserRepository(BuyerContext context)
        {
            _context = context;
        }
        public Buyer BuyerLogin(string username, string password)
        {
            Buyer buyer = _context.Buyer.SingleOrDefault(e => e.Buyername == username && e.Password == password);
            if (buyer.Buyername == username && buyer.Password == password)
                return buyer;
            else
            {
                Console.WriteLine("not a valid");
                return buyer;
            }
            
        }

        public void BuyerRegistration(Buyer buyer)
        {
            _context.Add(buyer);
            _context.SaveChanges();
        }
    }
}
