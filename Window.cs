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
        //TO DO find a way with lodical statments
        public static void CenterText(string text)
        {
            int space = Console.WindowWidth - text.Length;
            int spaceBeforeText = space / 2;
            Console.Write(new string(' ', spaceBeforeText));
            Console.WriteLine(text);
        }
        public void MainMenu()
        {
            Console.Clear();
            Window main = new Window();
            Console.WriteLine("1. ADD a new car");
            Console.WriteLine("2. EDIT an existing car");
            Console.WriteLine("3. DELETE an existing car");
            Console.WriteLine("4. SEARCH for an existing car");
            Console.WriteLine("5. DISPLAY all existing cars");
            Console.WriteLine("6. EXIT");

        }
        public static char GetUserInput()
        {
            ConsoleKeyInfo user_input = Console.ReadKey(true);
            return user_input.KeyChar;
        }
        public void RenderAddWindow()
        {
            Window window = new Window();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

        }
        public void RenderEditWindow()
        {
            Window window = new Window();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

        }
        public void RenderDeleteWindow()
        {
            Window window = new Window();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();

        }
        public void RenderSearchWindow()
        {
            Window window = new Window();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

        }

    }

}
