using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using UserService.Models;
using UserService.Repository;

namespace TestService
{
    [TestFixture]
    class TestUserService
    {
        UserRepository _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new UserRepository(new BuyerContext());
        }
        [Test]
        public void TestBuyerLogin()
        {

            var result = _repo.BuyerLogin("Karthik", "karthik123");
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestAddBuyer()
        {

         var   buyerid = "B31";
         var   username = "sai";
         var   password = "qasqws";
         var   email = "as@gmail.com";
         var   Mobileno = "9876543210";
         var   Datetime = DateTime.Now;

            var result = new Buyer { Buyerid = buyerid, Buyername = username };
            var mock = new Mock<IuserRepository>();
            mock.Setup(e => e.BuyerRegistration(result));
           // Assert.NotNull(result);
        }
    }
}
