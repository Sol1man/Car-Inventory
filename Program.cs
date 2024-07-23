namespace CarsApp
{
    internal class Program
    {
        //inicializing cars list
        static void Main(string[] args)
        {

            List<Car> carList = new List<Car>();
           //setting window UI 
            Window window = new Window();
            window.MainMenu();
            CarInventory inventory = new CarInventory();
            char user_input = Window.GetUserInput();

            switch (user_input)
            {
               case '1':
                   carList.Add(inventory.CreateCar());
                   break;
               case '2':
                    inventory.EditCarWindow();
                    break;
               case '3':
                    //inventory.Delete();
                    break;
               case '4':
                    //inventory.Search();
                    break;
                case '5':
                    inventory.DisplayAllCars();
                    break;
               default:
                    Console.WriteLine("Invalid input, please choose from the given list.");
                    break;

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
