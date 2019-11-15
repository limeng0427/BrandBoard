using Mofadeng.TechnicalTest.BrandBoard.Controllers;
using Mofadeng.TechnicalTest.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mofadeng.TechnicalTest.Test
{
    public class GroupUtilityTest
    {
        #region GetGroupName
        [Fact]
        public void GetGroupName_DefaultGroupItemNumber_ReturnRightName()
        {
            // Arrange
            string itemName = "A2";
            // Act
            var result = GroupUtility.GetGroupName(itemName);

            // Assert
            Assert.Equal("A-B", result);
        }

        [Fact]
        public void GetGroupName_CustomizedGroupItemNumber3_ReturnRightName()
        {
            // Arrange
            string itemName = "A2";
            // Act
            var result = GroupUtility.GetGroupName(itemName,3);

            // Assert
            Assert.Equal("A-C", result);
        }

        [Fact]
        public void GetGroupName_BoundaryGroupItemNumber1_ReturnRightName()
        {
            // Arrange
            string itemName = "A2";
            // Act
            var result = GroupUtility.GetGroupName(itemName, 1);

            // Assert
            Assert.Equal("A", result);
        }
        [Fact]
        public void GetGroupName_BoundaryGroupItemNumber3_ReturnRightName()
        {
            // Arrange
            string itemName = "Zoo";
            // Act
            var result = GroupUtility.GetGroupName(itemName, 2);

            // Assert
            Assert.Equal("Y-Z", result);
        }
        #endregion
    }
}
