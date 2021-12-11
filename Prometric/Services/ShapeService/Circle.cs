using Models.Base;
using System;

namespace ShapeService
{
    public class Circle : Shape  
    {
        public override double Radius { get; set; } 
 
        public Circle()
        {
            InstanceCounter<Circle>.Increase();
        }
        ~Circle()
        {
            InstanceCounter<Circle>.Decrease();
        }


        public Circle(double radius) : this()
        {  
            Radius = radius;
        }


        public override double Area()
        {
            //Area of circle = Pi*R*R  where R=Radius ,Pi=3.14
            if (ValidateInputs(Radius))
                return Radius * Radius * Math.PI;

            else
                return 0.0;
        }

        public override double Perimeter()
        {
            //Perimeter (circumference) of circle = 2*Pi*R where R=Radius ,Pi=3.14 
            if (ValidateInputs(Radius))
                return 2 * Math.PI * Radius;

            else
                return 0.0;
        }
    }

}
