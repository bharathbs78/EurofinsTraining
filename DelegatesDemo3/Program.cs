using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo3
{
    public delegate void NotificationDelegate(string msg);
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc1=new Account();
            acc1.notify += Notification.sendEmail;
            acc1.Deposit(1000);
            Console.WriteLine(acc1.Balance);
            acc1.notify += Notification.sendTxtMessage;
            acc1.notify += WhatsappNotification.sendMessage;
            acc1.Withdraw(500);
            Console.WriteLine(acc1.Balance);
        }
    }
    public class Account
    {
        public int Balance { get; private set; }
        public event NotificationDelegate notify;// cannot call this method outside account class
        public void Deposit(int amount)
        {
            Balance += amount;
            string msg = $"Your account has been credited {amount}";
            if(notify!=null)
                notify(msg);
            
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            string msg = $"Your account has been debited {amount}";
            if(notify!=null)
                notify(msg);
        }

    }
    public class Notification
    {
        public static void sendEmail(string msg)
        {
            //to send mail
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = "smtp.gmail.com"; // from this server mail will be sent
            //smtpClient.Port = 465;
            //smtpClient.Credentials = null;
            //MailMessage mailMessage= new MailMessage();
            //mailMessage.From = "";
            //mailMessage.To = "";
            //mailMessage.Subject = "";
            //mailMessage.Body = msg;
            //mailMessage.Attachments.Add();
            //smtpClient.Send(mailMessage);
            Console.WriteLine($"Mail: {msg}");
        }
        public static void sendTxtMessage(string msg)
        {
            Console.WriteLine($"Message : {msg}");
        }
    }
    public class WhatsappNotification
    {
        public static void sendMessage(string msg) 
        {
            Console.WriteLine($"Whatsapp : {msg}");
        }
    }
}
