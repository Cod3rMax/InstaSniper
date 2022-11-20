using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaSniper.Helper
{
    class LoadProxy
    {


        public static ConcurrentQueue<string> proxy;
        public static int TotalProxiesInTheList;
        public static void LoadProxiesList()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            do
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    if (ofd.FileName != "")
                    {
                        FileInfo Fi = new FileInfo(ofd.FileName);
                        Regex checkProxyInsideFile = new Regex("\\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\b:\\d{2,5}");

                        switch (Fi)
                        {
                            case var _ when Fi.Length < 11:
                                Console.WriteLine("File is empty!");
                                ofd.FileName = "";
                                Thread.Sleep(2200);
                                break;

                            case var _ when !checkProxyInsideFile.IsMatch(File.ReadAllText(ofd.FileName)):
                                Console.WriteLine("File does not contain proxies!");
                                ofd.FileName = "";
                                Thread.Sleep(2200);
                                break;


                            default:
                                proxy = new ConcurrentQueue<string>(File.ReadAllLines(ofd.FileName));
                                TotalProxiesInTheList = proxy.Count;
                                break;

                        }
                    }
                }
            } while (ofd.FileName == "");


        }




    }


}

