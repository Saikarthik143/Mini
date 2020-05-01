using System;
using System.Collections.Generic;
using System.Linq;
using BuyerService.Models;
using System.Threading.Tasks;

namespace BuyerService.Repository
{
    interface IBuyerRepository
    {
        void EditProfile(Buyer buyer);
        Buyer GetProfile(string buyerid);
    }
}
