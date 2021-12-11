using Models.Base;

namespace ShapeService
{
    // 
    public class Quadrilaterals : Shape 
    {
        public override double Width { get; set; }
        public override double Length { get; set; } 
 
        public Quadrilaterals()
        {
            InstanceCounter<Quadrilaterals>.Increase();
        }
        ~Quadrilaterals()
        {
            InstanceCounter<Quadrilaterals>.Decrease();
        }

        public Quadrilaterals(double width, double length) : this()
        { 
            Width = width;
            Length = length;
        } 

        public override double Area()
        {
            //Area of Square/Rectangle = width*length
            return Width * Length;
        }

        public override double Perimeter()
        {
            //Perimeter of Square/Rectangle = (width + length) * 2
            return (Width + Length) * 2;
        }
        public override string Name
        {
            get
            {
                // The name should take into account if all sides are the same length.
                if (Width.Equals(Length))
                    return "Square";
                else  
                    return "Rectangle"; 
            } 
        }
    }
}
