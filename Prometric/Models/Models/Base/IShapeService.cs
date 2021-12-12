using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    public interface IShapeService
    {
        /// <summary>
        /// To get Circle area
        /// </summary>
        /// <returns></returns>
        double GetCircleArea(double radius);
        /// <summary>
        /// To get Circle Perimeter
        /// </summary>
        /// <returns></returns>
        double GetCirclePerimeter(double radius);

        /// <summary>
        /// To get Triangle Area
        /// </summary>
        /// <returns></returns>
        double GetTriangleArea(double @base, double height, double side);

        // To get Triangle Perimeter
        double GetTrianglePerimeter(double @base, double height, double side);

        // To get Triangle Name
        string GetTriangleName(double @base, double height, double side);

        /// <summary>
        /// To get Quadrilateral aRea
        /// </summary>
        /// <returns></returns>
        double GetQuadrilateralArea(double width, double length);


        /// <summary>
        /// To get Quadrilateral Perimeter
        /// </summary>
        /// <returns></returns>
        double GetQuadrilateralPerimeter(double width, double length);

        // To get Quadrilateral Name
        string GetQuadrilateralName(double width, double length);
    }
}
