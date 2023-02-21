using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager.DataAccess.Entities;

namespace ContactManager.DataAccess
{
    public class ContactMapper
    {
        public static string ContactToString(Contact c) => $"{c.ContactID},{c.Name},{c.Email},{c.Phone},{c.Location}";
        public static Contact StringToContact(string s)
        {
            string[] details=s.Split(',');
            Contact c = new Contact
            {
                ContactID = int.Parse(details[0]),
                Name = details[1],
                Email = details[2],
                Phone = details[3],
                Location = details[4],
            };
            return c;
        }
    }
}
