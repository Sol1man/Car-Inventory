using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    internal class Window
    {
        public Window() 
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            CenterText("The Wheel Deal");
            CenterText("Find Your Perfect Car");
        }
        public static void CenterText(string text)
        {
            int space = Console.WindowWidth - text.Length;
            int spaceBeforeText = space / 2;
            Console.Write(new string(' ', spaceBeforeText));
            Console.WriteLine(text);
        }
        public void mainMenu()
        {
            Console.Clear();
            Window main = new Window();
            Console.WriteLine("To ADD a new car Press 1");
            Console.WriteLine("To EDIT an existing car Press 2");
            Console.WriteLine("To DELETE an existing car Press 3");
            Console.WriteLine("To SEARCH for an existing car Press 4");
        }
        public char GetUserInput()
        {

            ConsoleKeyInfo user_input = Console.ReadKey(true);
            return user_input.KeyChar;

        }


    }

}
