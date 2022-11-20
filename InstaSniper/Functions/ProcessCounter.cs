using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaSniper.Functions
{
    class ProcessCounter
    {

        // this class here will be responsible for counting the process.

        public static int TotalComboList
        {
            get
            {
                return Helper.LoadCombo.TotalComboList;
            }
            set{}
        }

        public static int Live { get; set; }
        public static int Dead { get; set; }

        public static int OldChecked { get; set; }

        public static int  NewChecked { get; set; }

        public static int cpm { get; set; }

        public static string lastHit { get; set; }


        public static void CalculateCPM()
        {
            for (;;)
            {
                
                    try
                    {
                        OldChecked = Functions.ProcessCounter.Live + Functions.ProcessCounter.Dead;
                        Thread.Sleep(5000);
                        NewChecked = Functions.ProcessCounter.Live + Functions.ProcessCounter.Dead;
                        cpm = (NewChecked - OldChecked) * 60;
                    }
                    catch { }
               GC.Collect();
            }
        }



        public static int TotalProxies
        {
            get
            {
                return Helper.LoadProxy.proxy.Count;
            }
            set
            {
            }
        }


        public static void ShowCounter()
        {
            Console.Title = String.Format("Total: {0} | Live: {1} | Dead: {2} Checking By Cod3rMax", TotalComboList, Live, Dead);
        }

        
    }
}