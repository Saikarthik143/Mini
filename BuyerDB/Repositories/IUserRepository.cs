using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuyerDB.Models;

namespace BuyerDB.Repositories
{
   public interface IUserRepository
    {
        Task<bool> BuyerRegistration(Buyer buyer);
        Task<Buyer> BuyerLogin(string userName, string password);
    }
}
