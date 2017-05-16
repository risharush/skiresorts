using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Ski_Resorts
{
    public class Serialization
    {
        public static XmlSerializer ser = new XmlSerializer(typeof(ListOfResorts));
        public static void Serialize(ListOfResorts lr)
        {
            
            using (FileStream fs = new FileStream("../../allresorts.xml", FileMode.OpenOrCreate))
            {
               ser.Serialize(fs, lr);
            }
            
        }
           
        public static ListOfResorts Deserialize(ListOfResorts lr)
        {
            ListOfResorts resorts = null;
            using (FileStream fs = new FileStream("../../allresorts.xml", FileMode.OpenOrCreate))
            {
                resorts = (ListOfResorts)ser.Deserialize(fs);

            }
            return resorts;
        }

    }
}
