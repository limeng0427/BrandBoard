using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;
using Mofadeng.TechnicalTest.BrandBoard.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Mofadeng.TechnicalTest.Test
{
    public class BrandBoardControllerTest
    {
        [Fact]
        public void Get_ReturnsAViewResult_WithAListOfBrandNameAndLogoURL()
        {
            // Arrange
            var controller = new BrandBoardController(null);

            // Act
            var result = controller.Get();

            // Assert
            Assert.Equal("A2", result.First().BrandName);
            Assert.Equal("https://worldcloudshops-ssl.cdn.aladdin.nz/media/manufacturer/a2.jpg", result.First().BrandURL);
            Assert.Equal(91, result.Count());
        }
    }
}
