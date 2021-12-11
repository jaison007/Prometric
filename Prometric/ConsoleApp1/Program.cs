using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Configuration;
using Models.Model;
using Models.Base;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { 
            try
            {
                //Console.WriteLine("Hello World!");
                Random random = new Random((int)DateTime.UtcNow.Ticks);

                double width, length, triangleBase, height, side1, radius;

                radius = 6;
                width = length = 2;
                triangleBase = height = side1 = 3;


                // Doing some basic validations 
                // Circles
                var firstCircle = new Circle(radius);
                var firstCircleArea = firstCircle.Area(); // Check Radius * Radius * Math.PI-> (6 * 6 * Math.PI);
                var firstCirclePerimeter = firstCircle.Perimeter(); // Check 2 * Math.PI * Radius-> Math.PI * 6

                // Triangles
                var firstTriangle = new Triangle(triangleBase, height, side1);
                var firstTriangleArea = firstTriangle.Area(); // Check (Height * base) / 2 -> (3*3)2
                var firstTrianglePerimeter = firstTriangle.Perimeter(); // Check Height + Base + Side1;->  3 + 3 + 3

                // Square
                var firstSquare = new Quadrilaterals(width, length);
                var firstSquareArea = firstSquare.Area(); // Check Width * Length-> 2 * 2
                var firstSquarePerimeter = firstSquare.Perimeter(); // Check (Width + Length) * 2 ->  ( 2 + 2) * 2

                // Rectangle
                var firstRectangle = new Quadrilaterals(width, length);
                var firstRectangleArea = firstRectangle.Area(); // Check Width * Length-> 2 * 2
                var firstRectanglePerimeter = firstRectangle.Perimeter(); // Check (Width + Length) * 2 ->  ( 2 + 2) * 2



                // to  track(in memory) the number of Shape objects created (per class)
                Console.WriteLine($"Total number of Circle is {InstanceCounter<Circle>.Count }");
                Console.WriteLine($"Total number of Triangle is {InstanceCounter<Triangle>.Count }");
                Console.WriteLine($"Total number of Square/ Rectangle is {InstanceCounter<Quadrilaterals>.Count }"); 

                var shapes = new List<Shape>{
                        new Circle(10),
                        new Circle(radius),
                        new Circle(11),
                        new Circle(3),
                        new Triangle(triangleBase, height, side1),
                            new Quadrilaterals(width, length),};


                // to sort a collection of Shapes by Area or Perimeter.
                var shapesByArea = ShapesByArea(shapes);
                var shapesByPerimeter = ShapesByPerimeter(shapes);

                // to serialize/store shapes in various formats on disk.
                SerializeShapes(shapes);

                // to  track(in memory) the number of Shape objects created (per class)
                Console.WriteLine($"Total number of Circle is {InstanceCounter<Circle>.Count }");
                Console.WriteLine($"Total number of Triangle is {InstanceCounter<Triangle>.Count }");
                Console.WriteLine($"Total number of Square/ Rectangle is {InstanceCounter<Quadrilaterals>.Count }");
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
        public static void SerializeShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                var isSaved = WriteToJsonFile<Shape>(shape); 
            }
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


                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
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
