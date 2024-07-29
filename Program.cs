using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarsApp
{
    internal class Program
    {
        //inicializing cars list
        static void Main(string[] args)
        {
            /*using (var context = new CarsContext())
            {
                //create entity object
                var car1 = new Car() {  Name = "Ford", Year = 2020, Color = Colors.White, Price = 100000, Type = Types.Sedan };

                //add entitiy to the context
                context.CarList.Add(car1);

                //save data to the database tables
                context.SaveChanges();

                Car searchCar = context.CarList.FirstOrDefault(c => c.Name == "Ford");
                Console.WriteLine(searchCar.Id); 
            }*/

            CarInventory inventory = new CarInventory();
            //inventory.ClearAllCars();
            string saveFolderPath = "D:/Projects/Cars App/CarsApp/CarsApp/cars.csv";
            inventory.LoadCarsFromCsv(saveFolderPath);
            bool continueProgram = true;
            while (continueProgram)
            {
                //setting window UI 
                Window window = new Window();
                window.MainMenu();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without showing it
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    inventory.SaveCars(saveFolderPath);
                    continueProgram = false; // Exit the program loop
                    Console.WriteLine("Exiting Car Inventory System...");
                }
                else
                {
                    char user_input = Window.GetUserInput();
                    switch (user_input)
                    {
                        case '1':
                            window.RenderAddWindow();
                            inventory.AddCar(inventory.CreateCar());
                            break;
                        case '2':
                            window.RenderEditWindow();
                            Console.WriteLine("Editing Car data:");
                            Console.Write("Enter Car ID: ");
                            int editId = Convert.ToInt32(Console.ReadLine());
                            inventory.EditCar(editId);
                            break;
                        case '3':
                            window.RenderDeleteWindow();
                            Console.WriteLine("Deleting a Car:");
                            Console.Write("Enter Car ID: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            inventory.DeleteCar(deleteId);
                            break;
                        case '4':
                            window.RenderSearchWindow();
                            Console.WriteLine("Searching a Car:");
                            Console.WriteLine("Search by: ");
                            Console.WriteLine("1.Car ID            2. Car Name");

                            int searchOption = Convert.ToInt32(Console.ReadLine());
                            if (searchOption == 1)
                            {
                                Console.Write("Enter Car ID: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Car car = inventory.SearchByCarId(id);
                                car.ToString();
                            }
                            else
                            {
                                Console.Write("Enter Car Name: ");
                                string name = Console.ReadLine();
                                List<Car> searchedCars = inventory.SearchByCarName(name);
                                foreach (Car car in searchedCars)
                                {
                                    car.ToString();
                                }
                            }
                            break;
                        case '5':
                            inventory.DisplayAllCars();
                            break;
                        default:
                            Console.WriteLine("Invalid input, please choose from the given list.");
                            break;

                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            }

        }
    }
}
