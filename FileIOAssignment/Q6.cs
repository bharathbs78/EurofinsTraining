using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FileIOAssignment
{
    public class Q6//do later
    {
        static void Main(string[] args)
        {
            ClsMaruthi maruthi = new ClsMaruthi();
            maruthi.Make = 1;
            maruthi.ModelName = "Maruthi";
            maruthi.HasPowerSteering = true;
            maruthi.hasAC= true;
            maruthi.BodyColor = "red";
            maruthi.radio=new ClsRadio();
            maruthi.radio.Make = 1;
            maruthi.radio.model = "radio";
            XmlSerializer xmlserializer = new XmlSerializer(typeof(ClsMaruthi));
            using (StreamWriter writer = new StreamWriter("xmlparse.xml"))
            {
             xmlserializer.Serialize(writer,maruthi);
            }
            using(StreamReader reader=new StreamReader("xmlparse.xml"))
            {
                ClsMaruthi demo=(ClsMaruthi)xmlserializer.Deserialize(reader);
            }
            SoapFormatter soapFormatter = new SoapFormatter();
            using (Stream writer = File.OpenWrite("soapparse.xml"))
            {
                soapFormatter.Serialize(writer,maruthi);
            }    
            using(Stream reader = File.OpenRead("soapparse.xml"))
            {
                ClsMaruthi demo=(ClsMaruthi)soapFormatter.Deserialize(reader);
            }
        }
         
    }
    [Serializable]
    public class ClsRadio
    {
        public int Make { get; set;}
        public string model { get; set; }
    }
    [Serializable]
    public class ClsCar
    {
        public string ModelName { get; set; }
        public ClsRadio radio { get; set; }
        public int Make { get; set; }
        public string BodyColor { get; set; }
        public bool hasAC { get; set; }
    }
    [Serializable]
    public class ClsMaruthi:ClsCar
    {
        public bool HasPowerSteering { get; set; }
    }

}
