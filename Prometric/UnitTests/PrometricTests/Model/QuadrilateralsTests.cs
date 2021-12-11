using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Base;
using ShapeService;

namespace Models.Model.Tests
{ 
    [TestClass()]
    public class QuadrilateralsTests
    {
        private Shape shapeObj = null; 
           
        [TestMethod("Square Area Test")]
        public void AreaTest()
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

        [TestMethod("Check Name - Square")]
        public void SquareNameTest()
        {
            //arrange
            double width, length;
            width = length = 5;
            string expectedPerimeter = "Square";

            //act
            var shapeObj = new Quadrilaterals(width, length);

            //Assert
            Xunit.Assert.Equal(expectedPerimeter, shapeObj.Name);
        }

        [TestMethod("Check Name - Rectangle")]
        public void RectangleNameTest()
        {
            //arrange
            double width, length;
            width = 100;
            length = 5;
            string expectedPerimeter = "Rectangle";

            //act
            var shapeObj = new Quadrilaterals(width, length);

            //Assert
            Xunit.Assert.Equal(expectedPerimeter, shapeObj.Name);
        }
    }
}