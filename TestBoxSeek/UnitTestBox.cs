using Moq;
using SeekBox.DTOs;
using SeekBox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBoxSeek
{
    public class UnitTestBox
    {
        [Fact]
        public void AddEventBox_Success()
        {
            // Arrange
            var myServiceMock = new Mock<IBoxService>();
            var statusBoxDto = new StatusBoxDto(); // Wprowadź odpowiednie dane testowe

            myServiceMock.Setup(x => x.AddEventBox(statusBoxDto))
                         .Returns(true);

            var myService = myServiceMock.Object;

            // Act
            var result = myService.AddEventBox(statusBoxDto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddPackage_Success()
        {
            // Arrange
            var myServiceMock = new Mock<IBoxService>();
            var packageDto = new PackageDto(); // Wprowadź odpowiednie dane testowe

            myServiceMock.Setup(x => x.AddPackage(packageDto))
                         .Returns(true);

            var myService = myServiceMock.Object;

            // Act
            var result = myService.AddPackage(packageDto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetPackage_Success()
        {
            // Arrange
            var myServiceMock = new Mock<IBoxService>();
            var packageNumber = Guid.NewGuid(); // Wprowadź odpowiednie dane testowe

            myServiceMock.Setup(x => x.GetPackage(packageNumber))
                         .ReturnsAsync(new object()); // Wprowadź odpowiednie dane testowe

            var myService = myServiceMock.Object;

            // Act
            var result = await myService.GetPackage(packageNumber);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RemovePackage_Success()
        {
            // Arrange
            var myServiceMock = new Mock<IBoxService>();
            var packageNumber = Guid.NewGuid(); // Wprowadź odpowiednie dane testowe

            myServiceMock.Setup(x => x.RemovePackage(packageNumber))
                         .Returns(true);

            var myService = myServiceMock.Object;

            // Act
            var result = myService.RemovePackage(packageNumber);

            // Assert
            Assert.True(result);
        }
    }
}
