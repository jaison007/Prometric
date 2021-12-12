using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Configuration; 
using Models.Base;
//using System.ComponentModel;
using Autofac;
using ShapeService;
using Autofac.Core;
using Autofac.Extras.Attributed;

namespace ConsoleApp1
{
    class Program
    {
        private static IContainer ContainerRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<ShapeService.ShapeService>().As<IShapeService>().InstancePerLifetimeScope();
           
            return builder.Build(); 
        }

        static void Main(string[] args)
        { 
            try
            { 
                Random random = new Random((int)DateTime.UtcNow.Ticks);

                var service = ContainerRoot().Resolve<Application>();


                Console.WriteLine("Enter Circle Radius:");
                var radius = Convert.ToDouble(Console.ReadLine()); 
                
                var firstCircleArea = service.GetCircleArea(radius);
                Console.WriteLine($"Circle Area is {firstCircleArea.ToString() }");
                var firstCirclePerimeter = service.GetCirclePerimeter(radius);
                Console.WriteLine($"Circle Perimeter is {firstCirclePerimeter.ToString() }");

                Console.WriteLine("Enter Triangle Base:");
                var @base = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Triangle Height:");
                var height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Triangle Side:");
                var side = Convert.ToDouble(Console.ReadLine());

                var firstTriangleArea = service.GetTriangleArea(@base, height, side);
                Console.WriteLine($"Triangle area is {firstTriangleArea.ToString() }");
                var firstTrianglePerimeter = service.GetTrianglePerimeter(@base, height, side);
                Console.WriteLine($"Triangle Perimeter is {firstTrianglePerimeter.ToString() }");           
                Console.WriteLine($"Triangle NAME is {service.GetTriangleName(@base, height, side) }");

                Console.WriteLine("Enter Square Width:");
                var width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Square Height:");
                var length = Convert.ToDouble(Console.ReadLine()); 

                var firstSquareArea = service.GetQuadrilateralArea(width, length);
                Console.WriteLine($"Square area is {firstSquareArea.ToString() }");
                var firstSquarePerimeter = service.GetQuadrilateralPerimeter(width, length);
                Console.WriteLine($"Square Perimeter is {firstSquarePerimeter.ToString() }");
                Console.WriteLine($"Square NAME is {service.GetQuadrilateralName(width, length) }");

                Console.WriteLine("Enter Rectangle Width:");
                width = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Rectangle Height:");
                length = Convert.ToDouble(Console.ReadLine());

                var firstRectangleArea = service.GetQuadrilateralArea(width, length);
                Console.WriteLine($"Rectangle area is {firstRectangleArea.ToString() }"); 
                var firstRectanglePerimeter = service.GetQuadrilateralPerimeter(width, length);
                Console.WriteLine($"Rectangle area is {firstRectanglePerimeter.ToString() }");
                Console.WriteLine($"Rectangle NAME is {service.GetQuadrilateralName(width, length) }");

                // to  track(in memory) the number of Shape objects created 
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"Total number of Circle is {InstanceCounter<Circle>.Count }");
                Console.WriteLine($"Total number of Triangle is {InstanceCounter<Triangle>.Count }");
                Console.WriteLine($"Total number of Square/ Rectangle is {InstanceCounter<Quadrilaterals>.Count }"); 
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("");


                // to sort a collection of Shapes by Area or Perimeter.
                var shapes = new List<Shape>{
                        new Circle(10),
                        new Circle(3),
                        new Circle(11),
                        new Circle(3),
                        new Triangle(3, 4, 5),
                            new Quadrilaterals(5, 5),}; 

                var shapesByArea = ShapesByArea(shapes);
                Console.WriteLine("");
                Console.WriteLine("--------------------- Shapes by Area in descending order --------------------------------");
                foreach (var shape in shapesByArea)
                {
                    Console.WriteLine($"Area of {shape.GetType().Name} is {shape.Area() }");
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("");

                var shapesByPerimeter = ShapesByPerimeter(shapes);
                Console.WriteLine("");
                Console.WriteLine("--------------------- Shapes by Perimeter in descending order --------------------------------");
                foreach (var shape in shapesByPerimeter)
                {
                    Console.WriteLine($"Perimeter of {shape.GetType().Name} is {shape.Perimeter() }");
                }
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("");


                // to serialize/store shapes in various formats on disk.
                Console.WriteLine("");
                Console.WriteLine("--------------------- Serialize Shapes in JSON format and save into disk --------------------------------");
                var allSavedSuccessfully = SerializeShapes(shapes);
                if (allSavedSuccessfully)
                    Console.WriteLine("----------------- File has been created Successfully. ------------------------------------");
                else
                    Console.WriteLine("----------------- Unexpected ERROR while saving to disk. ------------------------------------");
                Console.WriteLine("");

                // to  track(in memory) the number of Shape objects created 
                Console.WriteLine("");
                Console.WriteLine("--------------------- Track number of objects created --------------------------------");
                Console.WriteLine($"Total number of Circle is {InstanceCounter<Circle>.Count }");
                Console.WriteLine($"Total number of Triangle is {InstanceCounter<Triangle>.Count }");
                Console.WriteLine($"Total number of Square/ Rectangle is {InstanceCounter<Quadrilaterals>.Count }");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error:- {GetInternalExceptions(e) }");
            } 
        }

        /// <summary>
        /// To return all shapes order by Area in descending order
        /// </summary>
        /// <param name="shapes">List of shapes</param>
        /// <returns></returns>
        static List<Shape> ShapesByArea(List<Shape> shapes)
        {
            return shapes.OrderByDescending(a => a.Area()).ToList();
        }

        /// <summary>
        /// To return all shapes order by Perimeter in descending order
        /// </summary>
        /// <param name="shapes">List of shapes</param>
        /// <returns></returns>
        static List<Shape> ShapesByPerimeter(List<Shape> shapes)
        {
            return shapes.OrderByDescending(a => a.Perimeter()).ToList();
        }

        /// <summary>
        /// To write seriaized object into a file
        /// </summary>
        /// <param name="shapes">List of shapes</param>
        public static bool SerializeShapes(List<Shape> shapes)
        {
            bool allSaved = true;
            foreach (var shape in shapes)
            {
                var isSaved = WriteToJsonFile<Shape>(shape);
                if (!isSaved)
                {
                    allSaved = false;
                    break;
                }
            }

            return allSaved;
        }

        /// <summary>
        /// Writes the object instance to a Json file. 
        /// <typeparam name="T">The type of object being written to the file.</typeparam> 
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static bool WriteToJsonFile<T>(T objectToWrite, bool append = true)  
        {
            TextWriter writer = null;
            bool isSuccess = false;

            try
            {
                // To read file path from app.config
                var filePath = ConfigurationManager.AppSettings["SerializedFilePath"]; 
                filePath = string.IsNullOrEmpty(filePath) ? @"D:\TestFolder\Shapes.txt" : filePath;


                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
                writer = new StreamWriter(filePath, append);
                writer.WriteLine();
                writer.Write(contentsToWriteToFile);

                isSuccess = true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Unexpected Error while saving to disk:- {GetInternalExceptions(e) }");
                isSuccess = false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }

            return isSuccess;
        }

        /// <summary>
        /// To get the full exception 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static string GetInternalExceptions(Exception ex)
        {
            var innerException = ex.InnerException;
            string innerExceptionDetails = String.Empty;

            if (ex != null)
                innerExceptionDetails = $"{ex.Message}\r\n{ex.StackTrace}\r\n";

            while (innerException != null)
            {
                innerExceptionDetails += $"{innerException.Message}\r\n{innerException.StackTrace}\r\n";
                innerException = innerException.InnerException;
            }
            return innerExceptionDetails;
        }
    }
}
