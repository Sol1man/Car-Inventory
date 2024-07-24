using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    internal class Car
    {
        public int Id;
        public string Name;
        public Colors Color;
        public Types Type;
        public int Year;
        public double Price;

        public Car()
        {
        }

        public Car(int id, string name, Colors color, Types type, int year, double price )
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
            this.Type = type;
            this.Year = year;
            this.Price = price;
        }
        public override string ToString()
        {
            //creating car data string in csv format
            Window.CenterText("Car Details");
            Console.WriteLine("ID, Name, Color, Type, Year, Price.");
            string carInfo = $"{Id}, {Name}, {Color}, {Type}, {Year}, {Price}";
            Console.WriteLine(carInfo);

            return carInfo;
        }
        public Car FindCarWithID(List <Car> carList, int id)
        {
            foreach (Car car in carList)
            {
                if (car.Id == id)
                {
                    Car car2 = new Car();

                    return car; 
                }
            }
            return null;

        }
        public static Types SetType()
        {
            Types carType;
            Console.WriteLine("Select car type:");
            Console.WriteLine("1. Sedan");
            Console.WriteLine("2. SUV");
            Console.WriteLine("3. Hatchback");

            char choice = Window.GetUserInput();

            switch (choice)
            {
                case '1':
                    carType = Types.Sedan;
                    break;
                case '2':
                    carType = Types.SUV;
                    break;
                case '3':
                    carType = Types.Hatchback;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Type not set.");
                    carType = Types.Invalid;
                    break;
            }
            return carType;
        }
        public static Colors SetColor()
        {
            Colors carColor;
            Console.WriteLine("Select car type:");
            Console.WriteLine("1. Black");
            Console.WriteLine("2. White");
            Console.WriteLine("3. Red");
            Console.WriteLine("4. Blue");


            char choice = Window.GetUserInput();

            switch (choice)
            {
                case '1':
                    carColor = Colors.Black;
                    break;
                case '2':
                    carColor = Colors.White;
                    break;
                case '3':
                    carColor = Colors.Red;
                    break;
                case '4':
                    carColor = Colors.Blue;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Color not set.");
                    carColor = Colors.Invalid;
                    break;
            }
            return carColor;
        }

    }
}
