using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo1
{
    public delegate void MyDelegate(string text);// can hold pointer to any method od this signature  //  Delegate Declaration
    internal class Program
    {
        static void Main(string[] args)
        {
            //Greeting("Hellofrom Direct Invocation");
            MyDelegate d = new MyDelegate(Greeting);// address of the method  //instantiation of delegate and associates the method Greeting with the object.
            // Subscription is used to multicast a delegate
            Program p = new Program();
            d += p.Hi;// now d holds more than 1 method address // subscribing
            d -= Greeting;//unsubscribe
            //Invocation
            //dont' use dynamic binding here , doesn't contain Invoke() method
            d.Invoke("Hello from Delegate");
            //d("Message");
        }
        static void Greeting(string text) 
        { 
            Console.WriteLine($"Greeting : {text}");
        }
        public void Hi(string msg)
        {
            Console.WriteLine($"Hi: {msg}");
        }
    }
}
