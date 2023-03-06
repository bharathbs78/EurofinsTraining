using ContactManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{
    public class ContactsDBRepository : IContactsRepository
    {
        public void Delete(int id)
        {
            string delete = "delete from contacts1 where contactid=@id";
            IDbConnection conn=GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText= delete;
            IDbDataParameter p=cmd.CreateParameter();
            p.ParameterName="@id";
            p.Value=id;
            cmd.Parameters.Add(p);
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(int id, Contact contact)
        {
            string update = "update contacts1 set Name=@name,Email=@email,Phone=@phone,Location=@location where contactid=@id";
            IDbConnection conn=GetConnection();
            IDbCommand cmd= conn.CreateCommand();
            cmd.CommandText=update;
            IDbDataParameter p=cmd.CreateParameter();
            p.ParameterName = "@name";
            p.Value = contact.Name;
            cmd.Parameters.Add(p);
            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@email";
            p1.Value = contact.Email;
            cmd.Parameters.Add(p1);
            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@phone";
            p2.Value = contact.Phone;
            cmd.Parameters.Add(p2);
            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@location";
            p3.Value = contact.Location;
            cmd.Parameters.Add(p3);
            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@id";
            p4.Value = id;
            cmd.Parameters.Add(p4);
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Contact> GetAll()
        {
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "GetAllContacts";
            cmd.CommandType = CommandType.StoredProcedure;
            //string selectById = "select * from contacts1;";
            //cmd.CommandText = selectById;
            List<Contact> contacts = new List<Contact>();
            using (conn)
            {
                conn.Open();
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        contacts.Add(new Contact
                        {
                            ContactID = (int)dataReader[0],
                            Name = (string)dataReader["name"],
                            Email = (string)dataReader["email"],
                            Phone = dataReader.GetString(3),
                            Location = dataReader["location"].ToString()
                        });
                    }
                }
            }
            return contacts;
        }

        public Contact GetContact(int id)
        {
            IDbConnection conn = GetConnection();
            IDbCommand cmd=conn.CreateCommand();
            string selectById = "select * from contacts1 where contactid=@id";
            cmd.CommandText = selectById;   
            IDbDataParameter p=cmd.CreateParameter();
            p.ParameterName = "@id";
            p.Value = id;
            cmd.Parameters.Add(p);
            Contact contact = new Contact();
            using (conn)
            {
                conn.Open();
                IDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    contact.ContactID = (int)dataReader[0];
                    contact.Name= (string)dataReader["name"];
                    contact.Email= (string)dataReader["email"];
                    contact.Phone = dataReader.GetString(3);
                    contact.Location= dataReader["location"].ToString();
                }
            }
            return contact;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            string selectByLocation = "select * from contacts1 where location=@location";
            cmd.CommandText = selectByLocation;
            IDbDataParameter p = cmd.CreateParameter();
            p.ParameterName = "@location";
            p.Value = location;
            cmd.Parameters.Add(p);
            List<Contact> contacts = new List<Contact>();
            using (conn)
            {
                conn.Open();
                IDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    contacts.Add(new Contact
                    {
                        ContactID = (int)dataReader[0],
                        Name = (string)dataReader["name"],
                        Email = (string)dataReader["email"],
                        Phone = dataReader.GetString(3),
                        Location = dataReader["location"].ToString()
                    });
                }
            }
            return contacts;
        }

        public void Save(Contact contact)
        {
            IDbConnection conn = GetConnection();
           // string insertVal = $"insert into contacts1 values('{contact.Name}','{contact.Email}','{contact.Phone}','{contact.Location}')";//is prone to SQL injection
            string betterWay = "insert into contacts1 values(@name,@email,@phone,@location)";
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = betterWay;
            IDbDataParameter p1=cmd.CreateParameter();
            p1.ParameterName = "@name";
            p1.Value = contact.Name;
            cmd.Parameters.Add(p1);
            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@email";
            p2.Value = contact.Email;
            cmd.Parameters.Add(p2);
            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@phone";
            p3.Value = contact.Phone;
            cmd.Parameters.Add(p3);
            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@location";
            p4.Value = contact.Location;
            cmd.Parameters.Add(p4);
            //cmd.Parameters.AddWithValue("@name", contact.Name);
            //cmd.Parameters.AddWithValue("@email", contact.Email);
            //cmd.Parameters.AddWithValue("@phone", contact.Phone);
            //cmd.Parameters.AddWithValue("@location", contact.Location);

            using (conn)// automatically disposes resources once the control goes out of the block
            {
                // try
                //{
                conn.Open();
                cmd.ExecuteNonQuery();//only select is query. all others are non-query.
                                      // }
            }
           // finally
            //{
              //  conn.Close();
            //}
        }
        //method without any new keyword.
        private static IDbConnection GetConnection()
        {
            string provider=ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory factory=DbProviderFactories.GetFactory(provider);//factory of a factory
            IDbConnection conn=factory.CreateConnection();
            //SqlConnection conn = new SqlConnection();
            string config = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            conn.ConnectionString = config;
            return conn;
        }
    }
}
