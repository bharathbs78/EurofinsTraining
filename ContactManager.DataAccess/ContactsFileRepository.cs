using ContactManager.DataAccess.Entities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.DataAccess.Exceptions;

namespace ContactManager.DataAccess
{
    public class ContactsFileRepository : IContactsRepository
    {
        public void Delete(int id)
        {
            try
            {
                Contact c = GetContact(id);
                List<Contact> list = GetAll();
                list.Remove(c);
                StreamWriter sw = GetWriter(false);
                foreach (var item in list)
                {
                    sw.WriteLine(ContactMapper.ContactToString(item));
                }
            }
            catch(CannotSaveContactException e)
            {
                throw new CannotSaveContactException("Contacts cannot be saved");
            }
            }
        public void Edit(int id, Contact contact)
        {
            try
            {
                Contact c = GetContact(id);
                List<Contact> list = GetAll();
                int index = list.IndexOf(c);
                list.Remove(c);
                list.Insert(index, contact);
                foreach (var item in list)
                {
                    Save(item);
                }
            }
            catch(Exception e)
            {
                throw new ContactCannotBeEditedException("Contact Cannot be Edited", e);
            }
        }

        public List<Contact> GetAll()
        {
            List<Contact> list = new List<Contact>();
            StreamReader sr = GetReader();
            while (!sr.EndOfStream)
            {
                string contact= sr.ReadLine();
                string[] contacts=contact.Split(',');
                Contact c = ContactMapper.StringToContact(contact);
                list.Add(c);
            }
            sr.Close();
            return list;
        }

        public Contact GetContact(int id)
        {
                StreamReader sr = GetReader();
            try { 
                while (!sr.EndOfStream)
                {
                    string contact = sr.ReadLine();
                    string[] contacts = contact.Split(',');
                    if (contacts[0].Equals(id.ToString()))
                    {
                        sr.Close();
                        return ContactMapper.StringToContact(contact);
                    }
                }
                throw new NoContactFoundException("No Contacts Found");
            }
            finally
            {
                sr.Close();
            }
        }
        public List<Contact> GetContactsByLocation(string location)
        {
            StreamReader sr = GetReader();
            List<Contact> list=new List<Contact>(); 
            while (!sr.EndOfStream)
            {   string contact=sr.ReadLine();
                string[] contacts = contact.Split(',');
                if (contacts[4].Equals(location.ToString()))
                {
                    list.Add(ContactMapper.StringToContact(contact));
                }
            }
            return list;
        }

        public void Save(Contact contact)
        {
            string contactString=ContactMapper.ContactToString(contact);
            StreamWriter sw = GetWriter();
            sw.WriteLine(contactString);
            sw.Close();
        }

        private StreamReader GetReader() => new StreamReader(@"C:\Users\Admin\Desktop\contactManager.txt");
        private StreamWriter GetWriter(bool append=true) => new StreamWriter(@"C:\Users\Admin\Desktop\contactManager.txt",append);
    }
}
