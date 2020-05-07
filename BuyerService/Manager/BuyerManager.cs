using BuyerDB.Models;
using BuyerDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Extensions;

namespace BuyerService.Manager
{
    public class BuyerManager : IBuyerManager
    {
        private readonly IBuyerRepository _repo;
        public BuyerManager(IBuyerRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> EditProfile(Buyer buyer)
        {
            bool user = await _repo.EditProfile(buyer);
            if (user == true)
                return true;
            else
                return false;
        }

        public async Task<Buyer> GetBuyerProfile(string buyerId)
        {
            try
            {
                Buyer buyer = await _repo.GetBuyerProfile(buyerId);
                if (buyer.Buyerid == buyerId)
                    return buyer;
                else
                {
                    Console.WriteLine("Buyer Profile Not found");
                    return buyer;
                }
            }
            catch(MyAppException e)
            {
                throw e;
            }
        }
    }
}
