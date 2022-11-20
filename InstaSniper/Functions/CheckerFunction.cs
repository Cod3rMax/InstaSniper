using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaSniper.Functions
{
    class CheckerFunction
    {
        public static string dequeuedUsername = null;
        public static string dequeuedProxy = null;
        public static void CheckUsername(string username, string proxy)
        {
            try
            {

                RestClientOptions RequestOptions = new RestClientOptions("https://www.instagram.com/" + username + "/")
                {
                    Proxy = new WebProxy(proxy),
                    FollowRedirects = true,
                    RemoteCertificateValidationCallback = new RemoteCertificateValidationCallback(
                        (object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()),

                };


            using (RestClient client = new RestClient(RequestOptions))
            {
                    RestRequest httpRequest = new RestRequest();

                    var response = client.GetAsync(httpRequest).Result;

                    Regex myRegex = new Regex("ig_web_error_reports");

                    var jsonobject = JsonConvert.SerializeObject(response.Headers);

                    var check = myRegex.IsMatch(jsonobject);

                    switch (check)
                    {
                        case true:
                            Functions.ProcessCounter.Dead++;
                            Functions.ProcessCounter.ShowCounter();
                            Helper.SaveResults.SaveLiveProxies(proxy);
                            Helper.LoadProxy.proxy.Enqueue(proxy);
                            break;
                        default:
                            Functions.ProcessCounter.Live++;
                            Functions.ProcessCounter.ShowCounter();
                            Helper.SaveResults.SaveLiveProxies(proxy);
                            Helper.SaveResults.LiveResult(username);
                            Helper.ShowLiveResult.SaveLiveResult(username);
                            Functions.ProcessCounter.lastHit = username;
                            Helper.LoadProxy.proxy.Enqueue(proxy);
                            break;
                    }

                    

            }
            }
            catch (Exception)
            {
                Helper.LoadCombo.ComboListQueue.Enqueue(username);
            }





        }



        public static void StartChecking()
        {
            ProcessCounter.ShowCounter();

            for (;;)
            {
                if (Helper.LoadProxy.proxy.Count != 0 && Helper.LoadCombo.ComboListQueue.Count != 0)
                {
                        Helper.LoadCombo.ComboListQueue.TryDequeue(out dequeuedUsername);
                        Helper.LoadProxy.proxy.TryDequeue(out dequeuedProxy);
                        CheckUsername(dequeuedUsername, dequeuedProxy);
                        Thread.Sleep(2500);
                }

                else
                {
                    if (Helper.LoadProxy.proxy.Count == 0 && Helper.LoadCombo.ComboListQueue.Count != 0)
                    {

                        try
                        {
                            Helper.SaveResults.SaveProcessNotCheckedUsernames(Helper.LoadCombo.ComboListQueue);
                        }
                        catch
                        {

                        }

                        break;
                    }

                    break;
                }


               
            }

        }



    }
}
