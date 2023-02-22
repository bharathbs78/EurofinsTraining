using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.DataAccess;
using ContactManager.DataAccess.Entities;
namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContactsRepository contactsRepository = new ContactsFileRepository();
            Console.WriteLine("Contact Manager");
            while (true)
            {
                PrintMainMenu();
                switch(int.Parse(Console.ReadLine())) 
                {
                    case 1:
                        GetContactInfo();
                        break;


                        
                }
            }

        }
        static void PrintMainMenu()
        {
            Console.WriteLine("1. Create new Contact");
            Console.WriteLine("2. Edit Existing Contact");
            Console.WriteLine("3. Delete Existing Contact");
            Console.WriteLine("4. Get All Contacts");
            Console.WriteLine("5. Get Contact By Location");
            Console.WriteLine("6. Get Contact By ID");
        }
        static void GetContactInfo()
        {
            Contact contact=new Contact();
            Console.WriteLine("Enter ID");
            
        }
    }
}
