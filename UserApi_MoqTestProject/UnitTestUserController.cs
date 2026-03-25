using Microsoft.AspNetCore.Mvc;
using Moq;
using UsersWebApiMoq16_03_2026.Controllers;
using UsersWebApiMoq16_03_2026.Models;
using UsersWebApiMoq16_03_2026.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
       
       [TestMethod]
        public async Task Create_ReturnsBadRequest_WhenModelStateInvalid()
        {
        // Arrange
        _controller.ModelState.AddModelError("Email", "Required");
        var user = new User();

        // Act
        var result = await _controller.Create(user);

        // Assert
        Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        
        [TestMethod]
        
        public async Task Create_ReturnsCreatedAtAction_WhenValid()
        {
            // Arrange
            var user = new User
            {
                Name = "Test",
                Username = "testuser",
                Email = "test@test.com",
                Password = "1234"
            };

            _mockRepository
                .Setup(r => r.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(user);

            // Assert
            var createdResult = result.Result as CreatedAtActionResult;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual(nameof(UsersController.GetById), createdResult.ActionName);
        }

        [TestMethod]
        public async Task Create_CallsAddAsync_WhenValid()
        {
            // Arrange
            var user = new User
            {
                Name = "Test",
                Username = "testuser",
                Email = "test@test.com",
                Password = "1234"
            };

            // Act
            await _controller.Create(user);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        }

        
       [TestMethod]
        public async Task Create_ReturnsCreatedUser()
        {
            // Arrange
            var user = new User
            {
                Name = "Test",
                Username = "testuser",
                Email = "test@test.com",
                Password = "1234"
            };

            _mockRepository
                .Setup(r => r.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(user);

            // Assert
            var createdResult = result.Result as CreatedAtActionResult;

            Assert.IsNotNull(createdResult); // ✅ ADD THIS

            var returnedUser = createdResult.Value as User;

            Assert.IsNotNull(returnedUser); // ✅ ADD THIS
            Assert.AreEqual(user.Email, returnedUser.Email);
        }

        [TestMethod]
        public async Task GetById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _mockRepository
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
    public async Task GetById_ReturnsUserDto_WhenUserExists()
    {
        // Arrange
        var user = new User
        {
            Id = 1,
            Name = "Test",
            Username = "testuser",
            Email = "test@test.com"
                };

                _mockRepository
                    .Setup(r => r.GetByIdAsync(1))
                    .ReturnsAsync(user);

                // Act
                var result = await _controller.GetById(1);

                // Assert
                var dto = result.Value;

                Assert.IsNotNull(dto);
                Assert.AreEqual(user.Email, dto.Email);
            }

            [TestMethod]
        public async Task Login_ReturnsUnauthorized_WhenInvalidCredentials()
        {
            // Arrange
            var model = new LoginModel
            {
                Username = "wrong",
                Password = "1234"
            };

            _mockRepository
                .Setup(r => r.GetByUsernameAsync(model.Username))
                .ReturnsAsync((User)null);

            // Act
            var result = await _controller.Login(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task Login_ReturnsOk_WhenCredentialsAreValid()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Username = "testuser",
                Email = "test@test.com",
                Password = "1234"
            };

            var model = new LoginModel
            {
                Username = "testuser",
                Password = "1234"
            };

            _mockRepository
                .Setup(r => r.GetByUsernameAsync(model.Username))
                .ReturnsAsync(user);

            // Act
            var result = await _controller.Login(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }   
}
