namespace CarsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //inicializing cars list
            List<Car> carList = new List<Car>();
           //setting window UI 
            Window window = new Window();
            window.mainMenu();
            char user_input = window.GetUserInput();
            CarInventory inv = new CarInventory();

            switch (user_input)
            {
               case '1':

                   carList.Add(inv.Add());
                   break;
               case '2':
                   inv.Edit();
                   break;
               case '3':
                   inv.Delete();
                   break;
               case '4':
                   inv.Search();
                   break;
               default:
                    Console.WriteLine("Invalid input, please choose from the given list.");
                    break;

            }
            for (int i = 0; i < carList.Count; i++) 
                {
                Car car = carList[i];
                Console.WriteLine(carList[i].name);
                Console.WriteLine(carList[i].color);
                Console.WriteLine(carList[i].type);
            }
            /* Car car1 = new Car();
             car1.name = "Ford";
             car1.year = 1990;
             car1.color = Car.Colors.Blue.ToString();
             Console.WriteLine(car1.year); 
             Console.WriteLine(car1.color);
             Console.Read(); */

            //window.mainMenu();



        }
    }
}
