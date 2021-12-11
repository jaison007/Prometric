﻿using Newtonsoft.Json;
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
            builder.RegisterType<Circle>().As<IShape>().InstancePerLifetimeScope();
           
            return builder.Build(); 
        }

        static void Main(string[] args)
        { 
            try
            { 
                Random random = new Random((int)DateTime.UtcNow.Ticks); 
 
                var firstCircleArea = ContainerRoot().Resolve<Application>().GetCircleArea();
                Console.WriteLine($"Circle Area is {firstCircleArea.ToString() }");
                var firstCirclePerimeter = ContainerRoot().Resolve<Application>().GetCirclePerimeter();
                Console.WriteLine($"Circle Perimeter is {firstCirclePerimeter.ToString() }");

                var firstTriangleArea = ContainerRoot().Resolve<Application>().GetTriangleArea();
                Console.WriteLine($"Triangle area is {firstTriangleArea.ToString() }");
                var firstTrianglePerimeter = ContainerRoot().Resolve<Application>().GetTrianglePerimeter();
                Console.WriteLine($"Triangle Perimeter is {firstTrianglePerimeter.ToString() }");


                var firstSquareArea = ContainerRoot().Resolve<Application>().GetQuadrilateralArea();
                Console.WriteLine($"Square area is {firstSquareArea.ToString() }");
                var firstSquarePerimeter = ContainerRoot().Resolve<Application>().GetQuadrilateralPerimeter();
                Console.WriteLine($"Square Perimeter is {firstSquarePerimeter.ToString() }");


                var firstRectangleArea = ContainerRoot().Resolve<Application>().GetQuadrilateralArea();
                Console.WriteLine($"Rectangle area is {firstRectangleArea.ToString() }"); 
                var firstRectanglePerimeter = ContainerRoot().Resolve<Application>().GetQuadrilateralPerimeter();
                Console.WriteLine($"Rectangle area is {firstRectanglePerimeter.ToString() }");


                // to  track(in memory) the number of Shape objects created (per class)
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
                SerializeShapes(shapes);
                Console.WriteLine("----------------- File has been created Successfully. ------------------------------------");
                Console.WriteLine("");

                // to  track(in memory) the number of Shape objects created (per class)
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


                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
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
