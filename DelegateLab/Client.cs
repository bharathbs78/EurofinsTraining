using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLab
{
    public delegate void NotifyMe(string sInfo);
    internal class Client
    {
        static void Main(string[] args)
        {
            NotifyMe notify = new NotifyMe(Listener.GetNotifiedAgain);
            InvokeDelegate(notify);
            Listener lsnr = new Listener();
            NotifyMe d2 = new NotifyMe(lsnr.GetNotified);
            InvokeDelegate(d2);
        }
        public static void InvokeDelegate(NotifyMe d)
        {
            d("You are late paying your bills!!!");
        }
    }
    public class Listener
    {
        public void GetNotified(string sInfo)
        {
            Console.WriteLine($"I got notified with the following information {sInfo}");
        }
        public static void GetNotifiedAgain(string sInfo) 
        {
            Console.WriteLine($"I got notified with the following information {sInfo}");
        }
    }
}
