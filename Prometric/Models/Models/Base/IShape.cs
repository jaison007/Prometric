using Newtonsoft.Json;

namespace Models.Base
{
    public interface IShape
    { 
        [JsonIgnore]
        string Name { get;   }

        public abstract double Perimeter();
        public abstract double Area();
    }
}
