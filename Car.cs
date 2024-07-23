using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    internal class Car
    {
        public int id;
        public string name;
        public string color;
        public string type;
        public int year;
        public double price;

        public enum Colors
        {
            Black,
            White,
            Red,
            Blue
        };
        public enum Types
        {
            Sedan,
            SUV,
            Hatchback
        };
        
        public Car(int id, string name, string color, string type, int year, double price )
        {
            this.name = name;
            this.color = color;
            this.type = type;
            this.year = year;
            this.price = price;
        }
        
    }
}
