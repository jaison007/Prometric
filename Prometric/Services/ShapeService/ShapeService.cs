using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeService
{
    public class ShapeService : IShapeService
    { 
        private Circle Circle { get; set; }
        private Triangle Triangle { get; set; }
        private Quadrilaterals Quadrilaterals { get; set; }
        public ShapeService()
        {
            Circle = new Circle();
            Triangle = new Triangle();
            Quadrilaterals = new Quadrilaterals();
        }
        /// <summary>
        /// To get Circle area
        /// </summary>
        /// <returns></returns>
        public double GetCircleArea(double radius)
        {
            Circle.Radius = radius;
            return Circle.Area();
        }
        /// <summary>
        /// To get Circle Perimeter
        /// </summary>
        /// <returns></returns>
        public double GetCirclePerimeter(double radius)
        {
            Circle.Radius = radius;
            return Circle.Perimeter();
        }

        /// <summary>
        /// To get Triangle Area
        /// </summary>
        /// <returns></returns>
        public double GetTriangleArea(double @base, double height, double side)
        {
            Triangle.Base = @base;
            Triangle.Height = height;
            Triangle.Side2 = side;
            return Triangle.Area();
        }

        // To get Triangle Perimeter
        public double GetTrianglePerimeter(double @base, double height, double side)
        {
            Triangle.Base = @base;
            Triangle.Height = height;
            Triangle.Side2 = side;
            return Triangle.Perimeter();
        }

        // To get Triangle Name
        public string GetTriangleName(double @base, double height, double side)
        {
            Triangle.Base = @base;
            Triangle.Height = height;
            Triangle.Side2 = side;
            return Triangle.Name;
        }

        /// <summary>
        /// To get Quadrilateral aRea
        /// </summary>
        /// <returns></returns>
        public double GetQuadrilateralArea(double width, double length)
        {
            Quadrilaterals.Width = width;
            Quadrilaterals.Length = length;
            return Quadrilaterals.Area();
        }


        /// <summary>
        /// To get Quadrilateral Perimeter
        /// </summary>
        /// <returns></returns>
        public double GetQuadrilateralPerimeter(double width, double length)
        {
            Quadrilaterals.Width = width;
            Quadrilaterals.Length = length;
            return Quadrilaterals.Perimeter();
        }

        // To get Quadrilateral Name
        public string GetQuadrilateralName(double width, double length)
        {
            Quadrilaterals.Width = width;
            Quadrilaterals.Length = length;
            return Quadrilaterals.Name;
        }
    }
}
