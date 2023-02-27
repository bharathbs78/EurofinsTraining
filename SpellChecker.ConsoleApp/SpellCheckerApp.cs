using SpellChecker.Checker;
using SpellChecker.FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.ConsoleApp
{
    internal class SpellCheckerApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the path of the input file");
            string str=Console.ReadLine();
            IDataAccess access = new FileDataAccess();
            List<string> words=access.Load(str);
            ISpellChecker checker = new SpellCheckerCls();
            foreach (string word in words)
            {
                List<string> list = new List<string>();
                list=checker.CheckFile(word);
                foreach (string word2 in list)
                {
                    Console.WriteLine($"{word} : {word2} ");
                }
            }

        }
    }
}
