using Models.Base;
using System;

namespace Models.Model
{
    public class Circle : Shape  
    {
        public double Radius { get; set; }
        //public string Name {  get => ""; set => throw new NotImplementedException(); }
 
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
            return Radius * Radius * Math.PI;
        }

        public override double Perimeter()
        {
            //Perimeter (circumference) of circle = 2*Pi*R where R=Radius ,Pi=3.14
            return 2 * Math.PI * Radius;
        }
    }

}
