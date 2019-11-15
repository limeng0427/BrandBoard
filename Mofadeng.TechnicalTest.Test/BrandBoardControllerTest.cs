using Moq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Logging;
using Mofadeng.TechnicalTest.BrandBoard.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Mofadeng.TechnicalTest.Utilities;

namespace Mofadeng.TechnicalTest.Test
{
    public class BrandBoardControllerTest
    {
        #region Get
        [Fact]
        public void Get_RequestGrouppedBrandData_ReturnGrouppedData()
        {
            // Arrange
            var controller = new BrandBoardController(null);

            // Act
            var result = controller.Get();

            // Assert
            Assert.Equal("A-B", result.First().GroupName);
            Assert.Equal(15, result.First().Items.Count());
            Assert.Equal("A2", result.First().Items.First().BrandName);
            Assert.Equal("https://worldcloudshops-ssl.cdn.aladdin.nz/media/manufacturer/a2.jpg", result.First().Items.First().BrandURL);
            Assert.Equal(11, result.Count());
        }
        #endregion

        #region GroupBrandData
        [Fact]
        public void GroupBrandData_RequestToGroupData_ReturnGrouppedData()
        {
            // Arrange
            var controller = new BrandBoardController(null);
            var itemList = new List<BrandBoardItem>();
            itemList.Add(new BrandBoardItem() { 
                BrandName = "A1",
                BrandURL = "https://www.test.com/1.png"
            });
            itemList.Add(new BrandBoardItem()
            {
                BrandName = "B1",
                BrandURL = "https://www.test.com/2.png"
            });
            itemList.Add(new BrandBoardItem()
            {
                BrandName = "C1",
                BrandURL = "https://www.test.com/3.png"
            });
            itemList.Add(new BrandBoardItem()
            {
                BrandName = "Z1",
                BrandURL = "https://www.test.com/3.png"
            });
            // Act
            var grouppedData = controller.GroupBrandData(itemList);

            // Assert
            Assert.Equal(3, grouppedData.Count());
            Assert.Equal(2, grouppedData.First().Items.Count());
            Assert.Equal("A1", grouppedData.First().Items.First().BrandName);
            Assert.Equal("https://www.test.com/1.png", grouppedData.First().Items.First().BrandURL);
        }
        #endregion
    }
}
