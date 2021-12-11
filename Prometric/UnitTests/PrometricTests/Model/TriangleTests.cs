using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Base;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        private Shape shapeObj = null;


        [TestMethod("Square Triangle Test")]
        public void TriangleTest()
        {
            //arrange
            double width, length;
            width = length = 5;
            double expectedArea = width * length;

            //act
            var shapeObj = new Quadrilaterals(width, length);

            //Assert
            Xunit.Assert.Equal(expectedArea, shapeObj.Area());
        }

        [TestMethod("Square Perimeter Test")]
        public void PerimeterTest()
        {
            //arrange
            double width, length;
            width = length = 5;
            double expectedPerimeter = (width + length) * 2;

            //act
            var shapeObj = new Quadrilaterals(width, length);

            //Assert
            Xunit.Assert.Equal(expectedPerimeter, shapeObj.Perimeter());
        }
    }
}