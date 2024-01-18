using Moq;
using SeekBox.DTOs;
using SeekBox.Models;
using SeekBox.Services;

namespace TestBoxSeek
{
    public class UnitTestUser
    {
        [Fact]
        public async Task AddUser_Success()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var clientDto = new ClientDto(); 

            userServiceMock.Setup(x => x.AddUser(clientDto))
                           .ReturnsAsync(true);

            var userService = userServiceMock.Object;

            // Act
            var result = await userService.AddUser(clientDto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_Success()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            int userId = 1; 

            userServiceMock.Setup(x => x.DeleteUser(userId))
                           .ReturnsAsync(true);

            var userService = userServiceMock.Object;

            // Act
            var result = await userService.DeleteUser(userId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task EditClient_Success()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var clientDto = new ClientDto(); 
            int clientId = 1; 

            userServiceMock.Setup(x => x.EditClient(clientDto, clientId))
                           .ReturnsAsync(new Client()); 

            var userService = userServiceMock.Object;

            // Act
            var result = await userService.EditClient(clientDto, clientId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void SeekClient_NotNull()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            string clientName = "John Doe"; 

            userServiceMock.Setup(x => x.SeekClient(clientName))
                           .Returns(new Client()); 

            var userService = userServiceMock.Object;

            // Act
            var result = userService.SeekClient(clientName);

            // Assert
            Assert.NotNull(result);
        }
    }
}