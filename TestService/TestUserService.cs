using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using UserService.Models;
using UserService.Repository;
using UserService.Controllers;

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
        [TestCase("B0123","Sarath","sarath123#","sarath@gmail.com","9876543210")]
        [TestCase("B323", "tarath", "trath123#", "tarath@gmail.com", "9879543210")]
        [Description("Add Buyer Testing")]
        public void TestAddBuyer(string buyerid,string username,string password,string email,string contact)
        {

         var   Datetime = System.DateTime.Now;

            var buyer = new Buyer { Buyerid = buyerid, Buyername = username,Password=password,Email=email,Mobileno=contact };
            _repo.BuyerRegistration(buyer);
            var mock = new Mock<IuserRepository>();
            mock.Setup(e => e.BuyerRegistration(buyer));
            var result = _repo.BuyerLogin(username, password);
           Assert.NotNull(result);
        }
    }
}
