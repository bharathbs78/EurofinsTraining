using SpellChecker.FileAccess;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Checker
{
    public class SpellCheckerCls : ISpellChecker
    {
        private ConcurrentBag<string> bg =new ConcurrentBag<string>(new DictionaryDataAccess().Load("dictionary.txt"));
        public List<string> CheckFile(string word)
        {
            List<string> list = new List<string>();
            list = (List<string>) bg.Where(s=>s.Contains(word));
            ConcurrentDictionary<int, List<string>> dict = new ConcurrentDictionary<int, List<string>>();
            Parallel.ForEach(list, l =>
            {
                int value=Levenshteindistance.CalculateDistance(l, word);
                dict.AddOrUpdate(value, new List<string> { word }, (k, v) =>
                {
                    v.Add(word);
                    return v;
                });
            });
            dict.OrderBy(kv => kv.Key);
            List<string> li = new List<string>();
            int wordCount=0;
            return new List<string>((List<string>)dict.SelectMany(kv => kv.Value)).Take(10).ToList();

        }
    }
}
