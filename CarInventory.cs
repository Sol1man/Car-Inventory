using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    internal class CarInventory
    {
        private static int nextId = 1;

        public void DisplayCar(Car car)
        {
            Window.CenterText("Car Details");
            Console.WriteLine("Car Id:" + car.id);
            Console.WriteLine("Car Name: " + car.name);
            Console.WriteLine("Car Color: " + car.color);
            Console.WriteLine("Car Type: " + car.type);
            Console.WriteLine("Car Year: " + car.year );
            Console.WriteLine("Car Price: " + car.price + "$");
        }
        public void DisplayAllCars(List<Car> carList)
        {
            foreach (Car car in carList)
            {
                Window.CenterText("All Cars Details" );
                Window.CenterText($"There are {carList.Count} Cars in the  inventory");
                Window.CenterText("Car Id:" + car.id);
                Console.WriteLine("Car Name: " + car.name);
                Console.WriteLine("Car Color: " + car.color);
                Console.WriteLine("Car Type: " + car.type);
                Console.WriteLine("Car Year: " + car.year);
                Console.WriteLine("Car Price: " + car.price + "$");
                Window.CenterText("---------------------");
                Console.WriteLine("");
            }
        }
        public Car Add()
        {
            Console.Clear();
            Window main = new Window();
            Console.WriteLine("Adding New Car:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Color: ");
            string color = Console.ReadLine();
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            int id = nextId;
            Car car = new Car(nextId, name, color, type, year, price);
            nextId++;
            return car;
        }
        public void Edit()
        {
            Window window = new Window();

        }
        public void Delete()
        {
            Window window = new Window();

        }
        public void Search()
        {
            Window window = new Window();

        }
    }
}
