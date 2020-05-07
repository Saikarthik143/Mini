using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using UserService.Controllers;
using BuyerDB.Entity;
using BuyerDB.Models;
using UserService.Manager;
using BuyerDB.Repositories;
using System.Threading.Tasks;
namespace TestService
{
    [TestFixture]
    class TestUserService
    {
        IUserRepository _repo;
        [SetUp]
        public void Setup()
        {
            _repo = new UserRepository(new BuyerContext());
        }
        [TearDown]
        public void TearDown()
        {
            _repo = null;
        }
        /// <summary>
        /// Testing  buyer login success
        /// </summary>
        [Test]
        [Description("testing buyer login success case")]
        public void TestBuyerLogin_Success()
        {
            try
            {
               Task<Buyer> result = _repo.BuyerLogin("Karthik", "karthik123");
                Buyer buyer = result.Result;
                Assert.NotNull(buyer.Buyername);
               
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing  buyer login failure case
        /// </summary>
        [Test]
        [Description("testing buyer login failure case")]
        public void buyerLogin_unSuccessfull()
        {
            try
            {
                Task<Buyer> result = _repo.BuyerLogin("siddu", "abcdefg@");
                Assert.AreEqual(result.Result, null);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
         [TestCase("B0123","Sarath","sarath123#","sarath@gmail.com","9876543210")]
         [TestCase("B323", "tarath", "trath123#", "tarath@gmail.com", "9879543210")]
         [Description("Add Buyer Testing")]
        public void BuyerRegister_Success(string buyerid,string username,string password,string emailid,string contact)
        {

            var  Datetime = System.DateTime.Now;

            var buyer = new Buyer { Buyerid = buyerid, Buyername = username,Password=password,Email=emailid,Mobileno=contact,Datetime=Datetime};
            _repo.BuyerRegistration(buyer);
            var mock = new Mock<IUserRepository>();
            mock.Setup(e => e.BuyerRegistration(buyer));
            var result = _repo.BuyerLogin(username, password);
           Assert.NotNull(result);
        }
       

    }
}
