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
    internal class CarInventory
    {
        static List<Car> carList = new List<Car>();
        static int nextId = 1;


        public void DisplayAllCars()
        {
            //Check if there is no cars in the database
            if (carList.Count == 0)
            {
                Console.WriteLine("No Cars at the Inventory");
                return;
            }
            Window.CenterText("All Cars Details");
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
            //Read Cars info
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
            //Add new car to the database
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
            Colors newColor = Car.SetColor();
            Console.Write("New Type: ");
            Types newType = Car.SetType();
            Console.Write("New Year: ");
            int newYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("New Price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            //Change car data with new car data 
            carToEdit.Color = newColor;
            carToEdit.Type = newType;
            carToEdit.Year = newYear;
            carToEdit.Price = newPrice;

            Console.WriteLine("Car Edited Successfully!");
        }

        public void DeleteCar(int id)
        {
            //Search for the car in cars list using the ID
            Car carToDelete = carList.FirstOrDefault(c => c.Id == id);

            //Check if car id not found
            if (carToDelete == null)
            {
                Console.WriteLine("Car not found.");
            }
            carList.Remove(carToDelete);
            Console.WriteLine("Car Deleted Successfully!");

        }
        public Car SearchByCarId(int id)
        {
            Window window = new Window();

            //search for the car in cars list using the ID
            return carList.FirstOrDefault(c => c.Id == id);

        }
        public List<Car> SearchByCarName(string name)
        {
            Window window = new Window();

            //search for the car in cars list using the ID
            return carList.Where(car => car.Name.ToLower().Contains(name.ToLower())).ToList();
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

    }
}
