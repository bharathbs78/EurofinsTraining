using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
            IContactsRepository repo = new ContactsDBRepository();
            Contact c = new Contact
            {
                Name = "Sachin2",
                Email = "sachin2@bcci.com",
                Phone = "1299191921",
                Location = "Bengaluru"
            };
            TransferFunds(111, 222, 14000);
           // repo.Edit(1,c);
            //foreach(var contact in repo.GetAll())
            //{
            //    Console.WriteLine(contact.Name);
            //}
            //IContactsRepository contactsRepository = new ContactsFileRepository();
            //Console.WriteLine("Contact Manager");
            //while (true)
            //{
            //    PrintMainMenu();
            //    switch(int.Parse(Console.ReadLine())) 
            //    {
            //        case 1:
            //            contactsRepository.Save(GetContactInfo());
            //            break;
            //        case 2:
            //            EditContactInfo(contactsRepository);
            //            break;
            //        case 3:
            //            int id=int.Parse(Console.ReadLine());
            //            contactsRepository.Delete(id);
            //            break;
            //        case 4:
            //            List<Contact> contacts=contactsRepository.GetAll();
            //            foreach(Contact contact in contacts)
            //            {
            //                Console.WriteLine(ContactMapper.ContactToString(contact));
            //            }
            //            break;
            //        case 5:
            //            Console.WriteLine("Enter Location");
            //            string location=Console.ReadLine();
            //            List<Contact> c=contactsRepository.GetContactsByLocation(location);
            //            foreach(Contact contact in c)
            //            {
            //                Console.WriteLine(ContactMapper.ContactToString(contact));
            //            }
            //            break;
            //        case 6:
            //            Console.WriteLine("Enter id");
            //            int id1 = int.Parse(Console.ReadLine());
            //            Console.WriteLine(ContactMapper.ContactToString(contactsRepository.GetContact(id1)));
            //            break;    
            //    }
            //}

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
        public static bool TransferFunds(int fromAcc,int toAcc,int amount)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            SqlCommand cmd=conn.CreateCommand();
            cmd.CommandText = "update accounts set balance-=@amount where accno=@accno";
            IDbDataParameter p1=cmd.CreateParameter();
            p1.ParameterName = "@amount";
            p1.Value = amount;
            cmd.Parameters.Add(p1);
            IDbDataParameter p2=cmd.CreateParameter();
            p2.ParameterName = "@accno";
            p2.Value = fromAcc;
            cmd.Parameters.Add(p2);
            SqlCommand cmd1=conn.CreateCommand();
            cmd1.CommandText = "update accounts set balance+=@amount where accno=@accno";
            IDbDataParameter p = cmd1.CreateParameter();
            p.ParameterName = "@amount";
            p.Value = amount;
            cmd1.Parameters.Add(p);
            IDbDataParameter p3=cmd1.CreateParameter();
            p3.ParameterName = "@accno";
            p3.Value = toAcc;
            cmd1.Parameters.Add(p3);
            conn.Open();
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            cmd.Transaction= sqlTransaction;
            cmd1.Transaction= sqlTransaction;
            try
            {
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            Console.WriteLine("Done successfully");
            return true;
        }
    }
}
