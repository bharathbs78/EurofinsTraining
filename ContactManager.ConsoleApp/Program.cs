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
                        contactsRepository.Save(GetContactInfo());
                        break;
                    case 2:
                        EditContactInfo(contactsRepository);
                        break;
                    case 3:
                        int id=int.Parse(Console.ReadLine());
                        contactsRepository.Delete(id);
                        break;
                    case 4:
                        List<Contact> contacts=contactsRepository.GetAll();
                        foreach(Contact contact in contacts)
                        {
                            Console.WriteLine(ContactMapper.ContactToString(contact));
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Location");
                        string location=Console.ReadLine();
                        List<Contact> c=contactsRepository.GetContactsByLocation(location);
                        foreach(Contact contact in c)
                        {
                            Console.WriteLine(ContactMapper.ContactToString(contact));
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter id");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.WriteLine(ContactMapper.ContactToString(contactsRepository.GetContact(id1)));
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
        static Contact GetContactInfo()
        {
            try
            {
                Contact contact = new Contact();
                Console.Write("Enter ID");
                contact.ContactID = int.Parse(Console.ReadLine());
                Console.Write("Enter Name");
                contact.Name = Console.ReadLine();
                Console.Write("Enter Email ID");
                contact.Email= Console.ReadLine();
                Console.Write("Enter Number");
                contact.Phone = Console.ReadLine();
                Console.Write("Enter Location");
                contact.Location = Console.ReadLine();
                return contact;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        public static void EditContactInfo(IContactsRepository c)
        {
            try
            {
                Console.WriteLine("Enter id of contact to be changed");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new contact information");
                c.Edit(id, GetContactInfo());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
