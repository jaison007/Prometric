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
    public class CircleTests
    {
        private Shape shapeObj = null;

        [TestMethod("Circle Area Test")]
        public void CircleAreaTest()
        {
            //arrange
            double radius = 5;
            double expectedArea = radius * radius * Math.PI;

            //act
            var shapeObj = new Circle(radius);

            //Assert
            Xunit.Assert.Equal(expectedArea, shapeObj.Area()); 
        }
        [TestMethod("Circle Perimeter Test")]
        public void CirclePerimeterTest()
        {
            //arrange
            double radius = 5;
            double expectedPerimeter = 2 * Math.PI * radius;

            //act
            var shapeObj = new Circle(radius);

            //Assert
            Xunit.Assert.Equal(expectedPerimeter, shapeObj.Perimeter());
        }
    }
}