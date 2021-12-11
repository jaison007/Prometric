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
        protected IShape Shape { get; set; }

        protected double width, length, triangleBase, height, side1, radius;

        public Application(IShape shape)
        {
            Shape = shape ?? throw new ArgumentNullException("Shape is null"); //Injected  
        }

        /// <summary>
        /// To get Circle area
        /// </summary>
        /// <returns></returns>
        public double GetCircleArea()
        { 
            Shape.Radius = 5; 
            return Shape.Area();
        }
        /// <summary>
        /// To get Circle Perimeter
        /// </summary>
        /// <returns></returns>
        public double GetCirclePerimeter()
        {
            Shape.Radius = 5; 
            return Shape.Perimeter();
        }

        /// <summary>
        /// To get Triangle Area
        /// </summary>
        /// <returns></returns>
        public double GetTriangleArea()
        {
            this.Shape = new Triangle(5, 5, 5);  
            return this.Shape.Area();
        }

        // To get Triangle Perimeter
        public double GetTrianglePerimeter()
        {
            this.Shape = new Triangle(5, 5, 5); 
            return this.Shape.Perimeter();
        }

        // To get Triangle Name
        public string GetTriangleName()
        {
            this.Shape = new Triangle(5, 5, 5);
            return this.Shape.Name;
        }

        /// <summary>
        /// To get Quadrilateral aRea
        /// </summary>
        /// <returns></returns>
        public double GetQuadrilateralArea()
        {
            this.Shape = new Quadrilaterals(5, 5); 
            return this.Shape.Area();
        }


        /// <summary>
        /// To get Quadrilateral Perimeter
        /// </summary>
        /// <returns></returns>
        public double GetQuadrilateralPerimeter()
        {
            this.Shape = new Quadrilaterals(5, 5);
            return this.Shape.Perimeter();
        }

        // To get Quadrilateral Name
        public string GetQuadrilateralName()
        {
            this.Shape = new Quadrilaterals(5, 5);
            return this.Shape.Name;
        }
    }
}
