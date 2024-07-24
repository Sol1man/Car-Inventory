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
        static List<Car> carList = new List<Car>();
        static int nextId = 1;


        public void DisplayAllCars()
        {
            if (carList.Count == 0)
            {
                Console.WriteLine("No Cars at the Inventory");
                return;
            }
                Window.CenterText("All Cars Details" );
                Window.CenterText($"There are {carList.Count} Cars in the  inventory");
            foreach (Car car in carList)
            {
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
        }

        public void EditCar(int id)
        {
            //search for the car in cars list using the ID

            Car carToEdit = carList.FirstOrDefault(c => c.Id == id);   

            /*Car carToEdi = new Car();
            for (int i = 0; i < carList.Count; i++) {
                if (carList[i].Id == id)
                {
                    carToEdit = carList[i];
                }*/
            //Check if car id not found
            if (carToEdit == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            //adding new car name (or leave it the same)
            Console.Write("New Name (leave blank to keep the current name): ");
            string newName = Console.ReadLine();


            carToEdit.Name = string.IsNullOrEmpty(newName) ? carToEdit.Name : newName;

            //adding new car data
            Console.Write("New Color: ");
            Colors newColor = Car.SetColor();
            Console.Write("New Type: ");
            Types newType = Car.SetType();
            Console.Write("New Year: ");
            int newYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("New Price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            //changing car data with new car data 
            carToEdit.Color = newColor;
            carToEdit.Type = newType;   
            carToEdit.Year = newYear;
            carToEdit.Price = newPrice;
            
            Console.WriteLine("Car Edited Successfully!");
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
        public Car SearchCar(int id)
        {
            Window window = new Window();

            //search for the car in cars list using the ID
            return carList.FirstOrDefault(c => c.Id == id);

        }
    }
}
