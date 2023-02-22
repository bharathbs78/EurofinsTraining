using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace FileIOLab
{
    internal static class Extension
    {
        public static void ForEachIndexed<T,V>(this IDictionary<T,V> dictionary,Action<int> action)
        {
            for(int i = 0; i < dictionary.Count; i++)
            {
                action(i);
            }
        }
    }
}
