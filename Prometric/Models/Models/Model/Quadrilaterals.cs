using Models.Base;

namespace Models.Model
{
    // 
    public class Quadrilaterals : Shape 
    {
        public double Width { get; set; }
        public double Length { get; set; }
        //public string Name { get => ""; set => throw new NotImplementedException(); }
 
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
