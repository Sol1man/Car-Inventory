using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class CarInventory
    {
        static List<Car> carList = new List<Car>();
        //static int nextId = 1; needed only when dealing with files


        public void DisplayAllCars()
        {
            int carCount = ContextController.Context.CarList.Count();
            //Check if there is no cars in the database
            if (carCount == 0)
            {
                Console.WriteLine("No Cars at the Inventory");
                return;
            }
            Window.CenterText("All Cars Details");
            Window.CenterText($"There are {carCount} Cars in the  inventory");
            foreach (Car car in ContextController.Context.CarList)
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
            //Read Cars info
            Console.WriteLine("Adding New Car:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Color: ");
            Colors color = CarInventory.SetColor();
            Console.Write("Type: ");
            Types type = CarInventory.SetType();
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Car car = new Car(name, color, type, year, price);
            return car;
        }
        public void AddCar(Car car)
        {
            //Add new car to the database
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null");
            }
            ContextController.Context.CarList.Add(car);
            ContextController.Context.SaveChanges();
            Console.WriteLine("Car Added Successfully!");
        }

        public void EditCar(int id)
        {
            //search for the car in cars list using the ID

            Car carToEdit = ContextController.Context.CarList.FirstOrDefault(c => c.Id == id);

            //Check if car id not found
            if (carToEdit == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            //Add new car name (or leave it the same)
            Console.Write("New Name (leave blank to keep the current name): ");
            string newName = Console.ReadLine();

            carToEdit.Name = string.IsNullOrEmpty(newName) ? carToEdit.Name : newName;

            //Add new car data
            Console.Write("New Color: ");
            Colors newColor = CarInventory.SetColor();
            Console.Write("New Type: ");
            Types newType = CarInventory.SetType();
            Console.Write("New Year: ");
            int newYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("New Price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            //----------------------------------------------------------------------------------------?
            //Change car data with new car data 
            carToEdit.Color = newColor;
            carToEdit.Type = newType;
            carToEdit.Year = newYear;
            carToEdit.Price = newPrice;

            ContextController.Context.SaveChanges();
            Console.WriteLine("Car Edited Successfully!");
        }

        public void DeleteCar(int id)
        {
            //Search for the car in cars list using the ID
            Car carToDelete = ContextController.Context.CarList.FirstOrDefault(c => c.Id == id);

            //Check if car id not found
            if (carToDelete == null)
            {
                Console.WriteLine("Car not found.");
            }
            ContextController.Context.Remove(carToDelete);
            ContextController.Context.SaveChanges();
            Console.WriteLine("Car Deleted Successfully!");
        }

        public Car SearchByCarId(int id)
        {
            Window window = new Window();

            //search for the car in cars list using the ID
            return ContextController.Context.CarList.FirstOrDefault(c => c.Id == id);

        }
        public List<Car> SearchByCarName(string name)
        {
            Window window = new Window();

            //search for the car in cars list using the ID
            return ContextController.Context.CarList.Where(car => car.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        //Clears all data in the Database
        public void ClearAllCars()
        {
            ContextController.Context.RemoveRange(ContextController.Context.CarList);
            ContextController.Context.SaveChanges();
        }

        //Files Functions
        public void SaveCars(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Id,Name,Color,Type,Year,Price");
                foreach (Car car in carList)
                {
                    writer.WriteLine(car.ToString());
                }
            }
            Console.WriteLine("Cars saved Successfully!");
        }
        public void LoadCarsFromCsv(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' not found. Car list remains unchanged.");
                return;
            }

            carList.Clear(); // Clear existing car list before loading data from the file

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    if (values.Length != 6)
                    {
                        Console.WriteLine($"Loading Data Error: Invalid format in line: {line}");
                        continue; // Skip invalid lines
                    }

                    int id = int.Parse(values[0]);
                    string name = values[1];
                    Colors color = (Colors)Enum.Parse(typeof(Colors), values[2]);
                    Types type = (Types)Enum.Parse(typeof(Types), values[3]);
                    int year = int.Parse(values[4]);
                    double price = double.Parse(values[5]);

                    carList.Add(new Car(id, name, color, type, year, price));
                }
            }

            Console.WriteLine("Cars loaded successfully");
        }

        public Car FindCarWithID(List<Car> carList, int id)
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
        //Get user input for the car type and return corresponding enum value
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

        //Get user input for the car type and return corresponding enum value
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
 