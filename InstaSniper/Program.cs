using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Dapper;
using Newtonsoft.Json.Linq;
using Console = Colorful.Console;

namespace InstaSniper
{

    internal class Program
    {

        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }



        private static Thread CPMCalculatorThread = new Thread(Functions.ProcessCounter.CalculateCPM)
        {
            IsBackground = true,
            Priority = ThreadPriority.Lowest
        };


        public static Int64 FinalUserThreads;


        [STAThread]

        static void Main(string[] args)
        {


            var checkVersion = new WebClient();
            var response = checkVersion.DownloadString("https://pastebin.com/raw/454AR8Jd");
            JObject objects = JObject.Parse(response);


            if ((float)objects["Version"] > float.Parse(ConfigurationManager.ConnectionStrings["Version"].ConnectionString))
            {
                if (MessageBox.Show("There is a new version of InstaSniper, would you like to download it on our discord?","New Version Update",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("https://discord.gg/Dxh3yY3TqA");
                }
                else
                {
                    Console.WriteLine("******* STOOOOOOOOOP *******", Color.Red);
                    Console.WriteLine("Sorry this version stopped working, please update to the latest version on: [https://discord.gg/Dxh3yY3TqA]", Color.Gold);

                    Console.ReadKey();
                    Environment.Exit(1);

                }
            }



            Display.Header.InstaSniperHeader();



           bool StartChecking = false;
           do
           {

               Console.Write("[~] => ", Color.LawnGreen);
               Console.Write("Enter how many threads ");
               Console.Write("THREADS ", Color.Red);
               Console.Write("you want to use: ");
               var UserThreads = Console.ReadLine();

               try
               {
                   if (Int64.Parse(UserThreads) > 200)
                   {
                       Console.Write("[?] ", Color.Orange);
                       Console.Write("It is recommended to use less than 200 ");
                       Console.WriteLine("THREADS ", Color.Red);
                   }
                   else
                   {
                       FinalUserThreads = Int64.Parse(UserThreads);
                       StartChecking = true;
                   }

               }
               catch (Exception ex)
               {
                   Console.WriteLine("[x] Value Entered incorrect!", Color.Pink);
               }


           
            
           } while (!StartChecking);



           Console.Write("[~] => ", Color.LawnGreen);
           Console.Write("Choose type of proxy ");
           Console.Write("[HTTP, HTTPS, SOCKS5]: ", Color.Red);
           Console.ReadLine();

           Console.Clear();
           Display.Header.InstaSniperHeader();
           Console.Write("[~] => ", Color.LawnGreen);
           Console.Write("Choose proxy file: ");
           Thread.Sleep(2000);

           Helper.LoadCombo.LoadComboList();
           Helper.LoadProxy.LoadProxiesList();

           Console.Write("[DONE]", Color.Green);

           
           Thread.Sleep(3000);
           Console.Clear();
           Console.WriteLine("[+] => Checking Starting......", Color.Red);
           Display.ResultDisplay.DisplayResults();


           using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
           {
               var output = connection.Query("select * from Person", new DynamicParameters());

               if (output.ToList()[0].ShowDiscord == "true")
               {
                   Process.Start("https://discord.gg/Dxh3yY3TqA");
                   connection.Execute("Update Person set ShowDiscord='false'");
               }
           }


           CPMCalculatorThread.Start();

            for (int i = 0; i <= FinalUserThreads; i++)
            {
                new Thread(new ThreadStart(Functions.CheckerFunction.StartChecking)).Start();
            }


            Console.ReadKey();


        }

    }
}
