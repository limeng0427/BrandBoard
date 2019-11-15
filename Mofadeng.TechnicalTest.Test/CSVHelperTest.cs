using Mofadeng.TechnicalTest.BrandBoard.Controllers;
using Mofadeng.TechnicalTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mofadeng.TechnicalTest.Test
{
    public class CSVHelperTest
    {
        [Fact]
        public void Get_ReturnsAViewResult_WithAListOfBrandNameAndLogoURL()
        {
            // Arrange
            string path = "./Brands.csv";
            // Act

            var items = CSVHelper.ReadFromCSV<BrandBoardItem>(path);

            // Assert
            Assert.Equal(91, items.Count());
            Assert.Equal("Thompson's 汤普森", items.First().BrandName);
            Assert.Equal("https://worldcloudshops-ssl.cdn.aladdin.nz/media/manufacturer/9.png", items.First().BrandURL);
        }
    }
}
