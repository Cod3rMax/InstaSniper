using System;
using System.Drawing;
using Console = Colorful.Console;


namespace InstaSniper.Display
{
    class Header
    {


        private static readonly string Line1 = " ____ ____ ____ ____ ____ ____ ____ ____ ____ ____ ____ ";
        private static readonly string Line2 = "||I |||n |||s |||t |||a |||S |||n |||i |||p |||e |||r ||";
        private static readonly string Line3 = "||__|||__|||__|||__|||__|||__|||__|||__|||__|||__|||__||";
        private static readonly string Line4 = "|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|/__\\|";
        private static readonly string Line5 = "~ Made by Cod3rMax ~";
        private static readonly string Line6 = "{ Discord: https://discord.gg/Dxh3yY3TqA }";


        //────────┼────



        public static void InstaSniperHeader()
        {
            Console.WindowWidth = 130;
            Console.WindowHeight = 35;

            Console.WriteLine();

            Console.SetCursorPosition((int)Math.Round((Console.WindowWidth - Line1.Length) / 2.0),
                Console.CursorTop);
            Console.WriteLine(Line1, Color.Red);

            Console.SetCursorPosition((int)Math.Round((Console.WindowWidth - Line2.Length) / 2.0),
                Console.CursorTop);
            Console.WriteLine(Line2, Color.Red);

            Console.SetCursorPosition((int)Math.Round((Console.WindowWidth - Line3.Length) / 2.0),
                Console.CursorTop);
            Console.WriteLine(Line3, Color.Red);

            Console.SetCursorPosition((int)Math.Round((Console.WindowWidth - Line4.Length) / 2.0),
                Console.CursorTop);
            Console.WriteLine(Line4, Color.Red);

            Console.WriteLine();

            Console.SetCursorPosition((int)Math.Round((Console.WindowWidth - Line5.Length) / 2.0),
                Console.CursorTop);
            Console.WriteLine(Line5, Color.GreenYellow);

            Console.SetCursorPosition((int)Math.Round((Console.WindowWidth - Line6.Length) / 2.0),
                Console.CursorTop);
            Console.WriteLine(Line6, Color.Aqua);

            Console.WriteLine();
        }




    }
}
