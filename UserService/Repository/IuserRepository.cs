using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repository
{
   public interface IuserRepository
    {
        void BuyerRegistration(Buyer buyer);
        Buyer BuyerLogin(string username, string password);
    }
}
