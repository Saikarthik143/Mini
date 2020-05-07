using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BuyerDB.Repositories;
using BuyerService.Manager;
using BuyerDB.Entity;
namespace TestBuyerService
{ 
    [TestFixture]
    class BuyerTesting
    {
        IBuyerRepository buyerRepository;
        IBuyerManager buyerManager;
        [SetUp]
        public void SetUp()
        {
            buyerRepository = new BuyerRepository(new BuyerContext());
        }
    }
}
