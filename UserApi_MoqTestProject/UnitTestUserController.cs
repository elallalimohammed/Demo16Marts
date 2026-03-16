using Microsoft.AspNetCore.Mvc;
using Moq;
using UsersWebApiMoq16_03_2026.Controllers;
using UsersWebApiMoq16_03_2026.Models;
using UsersWebApiMoq16_03_2026.Repositories;

namespace UserApi_MoqTestProject
{
    
    [TestClass]
    public class UnitTestUserController
    {
        private Mock<IUserRepository> _mockRepository;
        private UsersController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();

            _controller = new UsersController(_mockRepository.Object);
        } 
       
   
    }   
}
