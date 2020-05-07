using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Models;

namespace UserService.Manager
{
    public interface IUserManager
    {
        Task<bool> BuyerRegistration(Buyer buyer);
        Task<Buyer> BuyerLogin(string username, string password);
    }
}
