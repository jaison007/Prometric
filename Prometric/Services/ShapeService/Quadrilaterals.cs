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
            try
            {
                if (ValidateInputs(Width) && ValidateInputs(Length))
                    return Width * Length;

                else
                    return 0.0;
            }
            catch
            {

            }
            return 0.0;
        }

        public override double Perimeter()
        {
            //Perimeter of Square/Rectangle = (width + length) * 2
            try 
            {
                if (ValidateInputs(Width) && ValidateInputs(Length))
                    return (Width + Length) * 2;

                else
                    return 0.0;
            }
            catch
            {

            }
            return 0.0;
        }
        public override string Name
        {
            get
            {
                // The name should take into account if all sides are the same length.
                try
                {
                    if (ValidateInputs(Width) && ValidateInputs(Length))
                    {
                        if (Width.Equals(Length))
                            return "Square";
                        else
                            return "Rectangle";
                    }
                    else
                        return "Unknown"; 
                }
                catch
                {

                }
                return "Unknown";
            } 
        }
    }
}
