using System;
using System.Collections.Generic;
using System.Linq;
using ItemService.Models;
using System.Threading.Tasks;

namespace ItemService.Repositories
{
  public  interface IItemService
    {
        List<Items> Search(string name);
        List<Category> GetCategories();
        List<Items> GetItems();
        List<Cart> GetCart(string buyerid);
        void BuyItem(Purchasehistory purchasehistory);
        List<Purchasehistory> GetPurchasehistories(string buyerid);
        List<SubCategory> GetSubCategories(string categoryid);
        void AddToCart(Cart cart);
        List<Cart> GetCarts(string buyerid);
    }
}
