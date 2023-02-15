using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Languages
{
    internal class program
    {
        static void Main(string[] args)
        {
            IDE ide=new IDE();
            ide.Languages.Add(new CSharp());
            ide.Languages.Add(new Java());
            ide.Languages.Add(new C());
            ide.WorkWithLanguages();
        }
    }
    public class IDE// define contract that all languages must implement using interface
    {
 /*       public Java Java { get; set; }
        public CSharp CSharp { get; set; }
        public C C { get; set; }*/
        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();
        public void WorkWithLanguages()
        {
/*          Console.WriteLine(Java.GetName());
            Console.WriteLine(Java.GetParadigm());
            Console.WriteLine(Java.GetUnit());
            Console.WriteLine(CSharp.GetName());
            Console.WriteLine(CSharp.GetParadigm());
            Console.WriteLine(CSharp.GetUnit());
            Console.WriteLine(C.GetName());
            Console.WriteLine(C.GetParadigm());
            Console.WriteLine(C.GetUnit());*/
            foreach(ILanguage language in Languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.GetParadigm());
                Console.WriteLine(language.GetUnit());
                Console.WriteLine("-------------------------------");
            }

        }
    }
    public interface ILanguage// the contract
    {
        string GetUnit();
        string GetParadigm();
        string GetName();
    }
    public abstract class OOLanguage:ILanguage{
        public string GetUnit()
        {
            return "Class";
        }
        public  string GetParadigm()
        {
            return "ObjectOriented";
        }
        public abstract string GetName();
    } 
    public abstract class ProceduralLanguage : ILanguage
    {
        public string GetUnit()
        {
            return "Function";
        }
        public string GetParadigm()
        {
            return "Procedural";
        }
        public abstract string GetName();

    }
    public class CSharp : OOLanguage
    {
        public override string GetName()
        {
            return "C Sharp";
        }
    }
    public class C : ProceduralLanguage
    {
        public override string GetName()
        {
            return "C";
        }
    }
    public class Java : OOLanguage
    {
        public override string GetName()
        {
            return "Java";
        }
    }
}
