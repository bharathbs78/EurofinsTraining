using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Checker
{
    public interface ISpellChecker
    {
        List<string> CheckFile(string word);
    }
}
