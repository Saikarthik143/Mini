using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Repositories;
using BuyerDB.Entity;
using BuyerDB.Models;


namespace UserService.Manager
{
   
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _iuserRepository;
        public UserManager(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        /* public Task<Buyer> BuyerLogin(string username, string password)
         {
             throw new NotImplementedException();
         }
 */
        public async Task<Buyer> BuyerLogin(string username, string password)
        {
            return await _iuserRepository.BuyerLogin(username, password);
        }

        public async Task<bool> BuyerRegistration(Buyer buyer)
        {
            return await _iuserRepository.BuyerRegistration(buyer);
        }
    }
}
