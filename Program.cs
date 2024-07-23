namespace CarsApp
{
    internal class Program
    {
        //inicializing cars list
        static void Main(string[] args)
        {

            bool continueProgram = true;
            while (continueProgram)
            {
                //setting window UI 
                Window window = new Window();
                window.MainMenu();
                CarInventory inventory = new CarInventory();
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
                        int deleteTd = Convert.ToInt32(Console.ReadLine());
                        inventory.DeleteCar(deleteTd);
                        break;
                    case '4':
                        window.RenderSearchWindow();
                        //inventory.Search();
                        break;
                    case '5':
                        inventory.DisplayAllCars();
                        break;
                    case '6':
                        continueProgram = false;
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please choose from the given list.");
                        break;

                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }

            /* Car car1 = new Car();
             car1.name = "Ford";
             car1.year = 1990;
             car1.color = Car.Colors.Blue.ToString();
             Console.WriteLine(car1.year); 
             Console.WriteLine(car1.color);
             Console.Read(); */

        }
    }
}
