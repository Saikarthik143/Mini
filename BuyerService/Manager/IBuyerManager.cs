using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Repositories;
using BuyerDB.Entity;
using BuyerDB.Models;

namespace BuyerService.Manager
{
  public  interface IBuyerManager
    {
        Task<bool> EditProfile(Buyer buyer);
        Task<Buyer> GetBuyerProfile(string buyerId);
    }
}
