using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace FileDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //save as binary

            //save();
            //readAll();
            //readline();
            //store contact info into file.
            //csv-Comma Separated Values
            //saveContact();
            //ReadContacts
            //ReadContacts();
            //SaveAsBinary();
            //ReadFromBinary();
            DriveInfo[] drives=DriveInfo.GetDrives();   
            foreach(DriveInfo drive in drives)
            {
                Console.WriteLine(drive.Name);
            }
            string[] files = Directory.GetFiles(@"C:\");
            foreach(string file in files)
            {
                Console.WriteLine(file);
            }
        }
        static void save()
        {
            string data = "Data Appended";
            StreamWriter sw = new StreamWriter("C:\\Users\\Admin\\Desktop\\file.txt", true);// for append if false then write
            try
            {
                sw.WriteLine(data);
            }
            //sw.Flush(); // used to write everything written to file without waiting for the buffer to fill
            finally
            {
                sw.Close();
            }// use this instead of Flush
        }
        static void readAll()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Admin\\Desktop\\file.txt");
            string allLines = sr.ReadToEnd();
            Console.WriteLine(allLines);
        }
        static void readLine()
        {
            StreamReader reader = new StreamReader("C:\\Users\\Admin\\Desktop\\file.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            reader.Close();

        }
        static void saveContact()
        {
            Contact contact = new Contact { ID = 111, Name = "abc", EmailId = "abc@123.com", Location = "xyz", Mobile = "1234567899" };
            //text format - structured data
            string csvData = $"{contact.ID},{contact.Name},{contact.EmailId},{contact.Location},{contact.Mobile}";
            StreamWriter sw = new StreamWriter("C:\\Users\\Admin\\Desktop\\file.txt", true);
            sw.WriteLine(csvData);
            sw.Close();

        }
        static void ReadContacts()
        {
            StreamReader r = new StreamReader("C:\\Users\\Admin\\Desktop\\file.txt");
            List<Contact> contacts = new List<Contact>();
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                //convert line into contact object
                string[] data = line.Split(',');
                Contact c = new Contact();
                c.ID = int.Parse(data[0]);
                c.Name = data[1];
                c.EmailId = data[2];
                c.Location = data[3];
                c.Mobile = data[4];
                contacts.Add(c);
            }
            r.Close();
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Name} : {c.Mobile}");
            }
        }
        static void SaveAsBinary()
        {
            Contact contact = new Contact { ID = 111, Name = "abc", EmailId = "abc@123.com", Location = "xyz", Mobile = "1234567899" };
            //text format - structured data
            BinaryFormatter bf = new BinaryFormatter();
            Stream s = File.Create("C:\\Users\\Admin\\Desktop\\contacts.dat");
            bf.Serialize(s, contact);
            s.Close();
        }
        static void ReadFromBinary()
        {
            Stream s = File.Open("C:\\Users\\Admin\\Desktop\\contacts.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Contact c = new Contact();
            c = (Contact)bf.Deserialize(s);
            Console.WriteLine(c.Name);
            s.Close();
        }
    }
    [Serializable]//called attribute in C#
    class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
    }
}
                                                                                                    