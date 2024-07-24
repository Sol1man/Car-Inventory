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

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without showing it
                if (keyInfo.Key == ConsoleKey.Escape)
                {
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
                            Console.WriteLine("Deleting a Car:");
                            Console.Write("Enter Car ID: ");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            Car car = inventory.SearchCar(searchId);
                            car.ToString();
                            break;
                        case '5':
                            inventory.DisplayAllCars();
                            break;
                        default:
                            Console.WriteLine("Invalid input, please choose from the given list.");
                            break;

                    }
                    //Console.WriteLine("Press any key to continue...");
                    //Console.ReadKey(true);
                }
            }

        }
    }
}
