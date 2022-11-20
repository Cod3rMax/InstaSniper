using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstaSniper.Helper
{


    class SaveResults
    {

        public static void SaveLiveProxies(string Proxy)
        {

            if (!File.Exists("Results/LiveProxies.txt"))
            {
                File.AppendAllText("Results/LiveProxies.txt", "");
            }


            if (!File.ReadAllLines("Results/LiveProxies.txt").Contains(Proxy))
            {
                File.AppendAllText("Results/LiveProxies.txt", Proxy + "\n");
            }

        }



        public static void LiveResult(string LiveUsername)
        {

            if (!File.Exists("Results/LiveUsername.txt"))
            {
                File.AppendAllText("Results/LiveUsername.txt", "");
            }


            if (!File.ReadAllLines("Results/LiveUsername.txt").Contains(LiveUsername))
            {
                File.AppendAllText("Results/LiveUsername.txt", LiveUsername + "\n");
            }


        }



        public static void SaveProcessNotCheckedUsernames(ConcurrentQueue<string> notchecked)
        {
            File.WriteAllLines("Results/NotChecked.txt", notchecked);
        }



    }
}
