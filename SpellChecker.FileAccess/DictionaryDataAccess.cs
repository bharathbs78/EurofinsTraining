using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.FileAccess
{
    public class DictionaryDataAccess : IDataAccess
    {
        public List<string> Load(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                List<string> list = new List<string>();
                list = reader.ReadToEnd().Split(' ', '\n').ToList();
                return list;
            }catch(Exception ex)
            {
                throw new FileCannotBeAccessedException("Cannot Access File", ex);
            }
        }
    }
}
