using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InstaSniper.Helper
{
    class LoadCombo
    {

        public static int TotalComboList;
        public static ConcurrentQueue<string> ComboListQueue;
        public static void LoadComboList()
        {

            try
            {
                ComboListQueue = new ConcurrentQueue<string>(File.ReadAllLines("Results/Combinations.txt"));
                TotalComboList = ComboListQueue.Count;
                Functions.ProcessCounter.ShowCounter();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Combinations.txt file doesn't exists!");
            }

        }


    }
}
