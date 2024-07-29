using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class Car
    {
        [Key]
        public int Id { get; set; } //Unique identifier for each car
        public string Name { get; set; }
        public Colors Color { get; set; }
        public Types Type { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        //Default constructor
        public Car()
        {
        }
        public Car(string name, Colors color, Types type, int year, double price)
        {
            this.Name = name;
            this.Color = color;
            this.Type = type;
            this.Year = year;
            this.Price = price;
        }
        public Car(int id,string name, Colors color, Types type, int year, double price )
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
