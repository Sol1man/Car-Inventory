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
        public int Id; //Unique identifier for each car
        public string Name;
        public Colors Color;
        public Types Type;
        public int Year;
        public double Price;

        //Default constructor
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

    }
}
