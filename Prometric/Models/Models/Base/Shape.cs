using System;

namespace Models.Base
{
    public abstract class Shape : InstanceCounter<Shape>, IShape
    {
        public virtual string Name { get =>"";  }

        public Shape()
        {
           // InstanceCounter<Shape>.Increase();
        }

        //public double Perimeter()
        //{
        //    throw new NotImplementedException();
        //}

        //public double Area()
        //{
        //    throw new NotImplementedException();
        //}

        public abstract double Perimeter();
        public abstract double Area();
    }

}
