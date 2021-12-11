using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Base;
using Models.Model;
using ShapeService;
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


        [TestMethod("Triangle Area Test")]
        public void TriangleAreaTest()
        {
            //arrange
            double @base, height, side;
            @base = height = side = 10;
            double expectedArea = (height * @base) / 2;  

            //act
            var shapeObj = new Triangle(@base, height, side);

            //Assert
            Xunit.Assert.Equal(expectedArea, shapeObj.Area());
        }

        [TestMethod("Triangle Perimeter Test")]
        public void TrianglePerimeterTest()
        {
            //arrange
            double @base, height, side;
            @base = height = side = 10;
            double expectedPerimeter = height + @base + side;

            //act
            var shapeObj = new Triangle(@base, height, side);

            //Assert
            Xunit.Assert.Equal(expectedPerimeter, shapeObj.Perimeter());
        }

        [TestMethod("Triangle Name Test")]
        public void TriangleNameTest()
        {
            double @base, height, side;
            @base = height = side = 10;
            string expectedName = "equilateral";

            //act
            var shapeObj = new Triangle(@base, height, side);

            //Assert
            Xunit.Assert.Equal(expectedName, shapeObj.Name);
        }
    }
}