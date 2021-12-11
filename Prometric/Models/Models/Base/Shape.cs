using System;

namespace Models.Base
{
    public abstract class Shape : InstanceCounter<Shape>, IShape
    {
        public virtual string Name { get =>"";  }
        public virtual double Radius { get ; set ; }
        public virtual double Base { get; set; }
        public virtual double Height { get; set; }
        public virtual double Side2 { get; set; }
        public virtual double Width { get; set; }
        public virtual double Length { get; set; }

        public Shape()
        { 
        } 

        public abstract double Perimeter();
        public abstract double Area();

        public bool ValidateInputs(double value)
        {
            if (Math.Abs(value) <= Double.Epsilon)
                return false; 
            else
                return true;

        } 
    }

}
