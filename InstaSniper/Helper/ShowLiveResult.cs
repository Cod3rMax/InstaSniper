using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaSniper.Helper
{
    internal class ShowLiveResult
    {

        public static List<string> LiveResult = new List<string>();

        public static void SaveLiveResult(string username)
        {
            LiveResult.Add(username);
        }



        public static List<string> ShowTheLiveResult()
        {
            return LiveResult;
        }


    }
}
