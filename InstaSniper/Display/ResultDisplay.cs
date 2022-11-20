using System.Drawing;
using Console = Colorful.Console;
using System.Threading;
using System.Threading.Tasks;

namespace InstaSniper.Display
{
    class ResultDisplay
    {


        public static readonly string Line1   = "╔═════════════════════════════════════════════════════════════════════════════════════════════════════╗";
        public static readonly string Line2   = "║                                     [~]Checking Results[~]                                          ║";
        public static readonly string Line3   = "║═════════════╗═══════════╗════════════╗════════════════╗═════════════════════╗══════════════╗════════║";
        public static readonly string Line4   = "║ Total List  ║   Live    ║     Dead   ║    Checked     ║     Proxy Left      ║     CPM      ║        ║";
        public static readonly string Line5   = "║             ║           ║            ║                ║                     ║              ║        ║";
        public static readonly string Line6   = "║\t   {0}         {1}          {2}            {3}               {4}                   {5}                                 ";
        public static readonly string Line7   = "║             ║           ║            ║                ║                     ║              ║        ║";
        public static readonly string Line8   = "║═════════════╝═══════════╝════════════╝════════════════╝═════════════════════╝══════════════╝════════║";
        public static readonly string Line9   = "║ [*]Last Hit: {0}                             ║ [*] Total Proxies: {1}                                        ";
        public static readonly string Line10  = "╚═════════════════════════════════════════════════════════════════════════════════════════════════════╝";


        public static void DisplayResults()
        {

            Task.Factory.StartNew(() =>
            {

                for (; ; )
                {


            Console.BufferWidth = Console.WindowWidth;
            Console.WriteLine();

            Display.Header.InstaSniperHeader();

            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line1);

            Console.SetCursorPosition((Console.WindowWidth - Line2.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line2);


            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line3);
            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line4);
            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line5);
            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2 , Console.CursorTop);
            Console.WriteLine(Line6, Helper.LoadCombo.TotalComboList, Functions.ProcessCounter.Live, Functions.ProcessCounter.Dead, Functions.ProcessCounter.Live + Functions.ProcessCounter.Dead, Helper.LoadProxy.proxy.Count, Functions.ProcessCounter.cpm);

            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line7);
            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line8);
            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line9, Functions.ProcessCounter.lastHit, Helper.LoadProxy.TotalProxiesInTheList);


            Console.SetCursorPosition((Console.WindowWidth - Line1.Length) / 2, Console.CursorTop);
            Console.WriteLine(Line10);

            Console.WriteLine();

            foreach (var username in Helper.ShowLiveResult.ShowTheLiveResult())
            {
                Console.WriteLine("[** {0} **] => Looks like free, please try a manual check :)", username, Color.Gold);
            }

            Thread.Sleep(3000);
            Console.Clear();

                }
            });

        }
    }
}
