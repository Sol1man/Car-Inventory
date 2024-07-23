using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    internal class CarInventory
    {
        List<Car> carList = new List<Car>();
        private static int nextId = 1;


        public void DisplayAllCars()
        {
            foreach (Car car in carList)
            {
                Window.CenterText("All Cars Details" );
                Window.CenterText($"There are {carList.Count} Cars in the  inventory");
                Window.CenterText("Car Id:" + car.Id);
                Console.WriteLine("Car Name: " + car.Name);
                Console.WriteLine("Car Color: " + car.Color);
                Console.WriteLine("Car Type: " + car.Type);
                Console.WriteLine("Car Year: " + car.Year);
                Console.WriteLine("Car Price: " + car.Price + "$");
                Window.CenterText("---------------------");
                Console.WriteLine("");
            }
        }
        public Car CreateCar()
        {
            Console.Clear();
            Window main = new Window();
            Console.WriteLine("Adding New Car:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Color: ");
            Colors color = Car.SetColor();
            Console.Write("Type: ");
            Types type = Car.SetType();
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            int id = nextId;
           /* if (Car.Id == null) 
            { 
            }*/
            Car car = new Car(nextId, name, color, type, year, price);
            nextId++;
            return car;
        }
        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null");
            }
            carList.Add(car);
            Console.WriteLine("Car Added Successfully!");
            carList.Add(car);
        }

        public void EditCar(int id)
        {
            //search for the car in cars list using the ID
               Car carToEdit = carList.FirstOrDefault(c => c.Id == id);   

            //Check if car id not found
            if (carToEdit == null)
            {
                Console.WriteLine("Car not found.");
            }

            //adding new car name (or leave it the same)
            Console.Write("New Name (leave blank to keep the current name): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                carToEdit.Name = newName;
            }

            //adding new car data
            Console.Write("New Color: ");
            Colors newColor = Car.SetColor();
            Console.Write("New Type: ");
            Types newType = Car.SetType();
            Console.Write("New Year: ");
            int newYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("New Price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Car Edited Successfully!");
        }
        public void EditCarWindow()
        {
            Console.Clear();
            Window window = new Window();
            Console.WriteLine("Editing Car data:");
            Console.Write("Enter Car ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            EditCar(id);
        }
        public void DeleteCar(int id)
        {
            //search for the car in cars list using the ID
            Car carToDelete = carList.FirstOrDefault(c => c.Id == id);

            //Check if car id not found
            if (carToDelete == null)
            {
                Console.WriteLine("Car not found.");
            }
            carList.Remove(carToDelete);
            Console.WriteLine("Car Deleted Successfully!");

        }
        public void SearchCar()
        {
            Window window = new Window();

        }
    }
}
