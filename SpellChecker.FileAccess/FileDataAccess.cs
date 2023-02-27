using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.FileAccess
{
    public class FileDataAccess : IDataAccess
    {
        /// <summary>
        /// Return a list containing the words in the path mentioned.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List<string></returns>
        public List<string> Load(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                List<string> strings = new List<string>();
                strings = reader.ReadToEnd().Split(new char[] { ' ' }).ToList();
                return strings;
            }
            catch(Exception ex)
            {
                throw new FileCannotBeAccessedException("Cannot access file", ex);
            }
        }
    }
}
