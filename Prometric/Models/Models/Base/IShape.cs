using Newtonsoft.Json;

namespace Models.Base
{
    public interface IShape
    {
        double Radius { get; set; }
        double Base { get; set; }
        double Height { get; set; } // Side1
        double Side2 { get; set; }

        double Width { get; set; }
        double Length { get; set; }


        [JsonIgnore]
        string Name { get;   }

        abstract double Perimeter();
        abstract double Area();
    }
}
