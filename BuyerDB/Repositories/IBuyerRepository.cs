using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuyerDB.Models;

namespace BuyerDB.Repositories
{
  public  interface IBuyerRepository
    {
        Task<bool> EditProfile(Buyer buyer);
        Task<Buyer> GetBuyerProfile(string buyerId);
    }
}
