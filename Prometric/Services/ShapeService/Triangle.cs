using Models.Base;
using System;

namespace ShapeService
{
    public class Triangle : Shape 
    { 
        public override double Base { get; set; }
        public override double Height { get; set; } // Side1
        public override double Side2{ get; set; } 

        //public static int Count = 0;
        public Triangle()  
        {
            InstanceCounter<Triangle>.Increase();
        }
        ~Triangle()
        {
            InstanceCounter<Triangle>.Decrease();
        }

        public Triangle(double @base, double height, double side2) : this()
        {
            Base = @base;
            Height = height;
            Side2 = side2; 
        }
        public override string Name
        {
            get
            {
                // if it is equilateral (all 3 sides are the same length), isosceles (only 2 sides are the same length) or scalene (no 2 sides are the same).
                if (Height.Equals(Base).Equals(Side2))
                    return "equilateral";
                else if (Height.Equals(Base) || Side2.Equals(Base) || Height.Equals(Side2))
                    return "isosceles";
                else
                    return "scalene";
            } 
        }
        public override double Area()
        {
            // Area of triangle = (Height * base) / 2
            return (Height * Base) / 2;
        }

        public override double Perimeter()
        {
            //Perimeter of triangle = a + b +c
            return Height + Base + Side2;
        }
    }
}
