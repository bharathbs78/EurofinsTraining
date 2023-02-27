using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.FileAccess
{
    public class FileCannotBeAccessedException:ApplicationException
    {
        public FileCannotBeAccessedException(string message,Exception e) : base(message,e) { }
    }
}
