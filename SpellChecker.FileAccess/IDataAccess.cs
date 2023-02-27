using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.FileAccess
{
    public interface IDataAccess
    {
        List<string> Load(string path);
    }
}
