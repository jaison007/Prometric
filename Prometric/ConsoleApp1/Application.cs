using Autofac.Extras.Attributed;
using Models.Base;
using ShapeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Application
    {
        protected IShapeService ShapeService { get; set; }

        protected double width, length, triangleBase, height, side1, radius;

        public Application(IShapeService shapeService)
        {
            ShapeService = shapeService ?? throw new ArgumentNullException("service  is null"); //Injected  
        }

        /// <summary>
        /// To get Circle area
        /// </summary>
        /// <returns></returns>
        public double GetCircleArea(double radius)
        {
            return ShapeService.GetCircleArea(radius);
        }
        /// <summary>
        /// To get Circle Perimeter
        /// </summary>
        /// <returns></returns>
        public double GetCirclePerimeter(double radius)
        {
            return ShapeService.GetCirclePerimeter(radius); 
        }

        /// <summary>
        /// To get Triangle Area
        /// </summary>
        /// <returns></returns>
        public double GetTriangleArea(double @base, double height, double side)
        {
            return ShapeService.GetTriangleArea(@base, height, side);
        }

        // To get Triangle Perimeter
        public double GetTrianglePerimeter(double @base, double height, double side)
        {
            return ShapeService.GetTrianglePerimeter(@base, height, side);
        }

        // To get Triangle Name
        public string GetTriangleName(double @base, double height, double side)
        {
            return ShapeService.GetTriangleName(@base, height, side);
        }

        /// <summary>
        /// To get Quadrilateral aRea
        /// </summary>
        /// <returns></returns>
        public double GetQuadrilateralArea(double width, double length)
        {
            return ShapeService.GetQuadrilateralArea(width, length);
        }


        /// <summary>
        /// To get Quadrilateral Perimeter
        /// </summary>
        /// <returns></returns>
        public double GetQuadrilateralPerimeter(double @width, double length)
        {
            return ShapeService.GetQuadrilateralPerimeter(width, length);
        }

        // To get Quadrilateral Name
        public string GetQuadrilateralName(double @width, double length)
        {
            return ShapeService.GetQuadrilateralName(width, length);
        }
    }
}
