using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using System.Xml.Serialization;
namespace XmlToOracleData
{
    public class SerializationHelper
    {
        /// <summary>
        /// Serialize the object into an XML format
        /// </summary>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        /// <param name="pObject">the object to serialize</param>
        /// <returns>a string representing the XML version of the object</returns>
        public static String SerializeObject<T>(T pObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            UTF8Encoding encoding = new UTF8Encoding();

            XmlSerializer xs = new XmlSerializer(typeof(T));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, (object)pObject);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            return encoding.GetString(memoryStream.ToArray());
        }

        /// <summary>
        /// Deserialize the object back into the object from an XML string
        /// </summary>
        /// <typeparam name="T">Type of the object to restore</typeparam>
        /// <param name="pXmlizedString">The string that represents the object in XML</param>
        /// <returns>A new instance of the restored object</returns>
        public static T DeserializeObject<T>(String pXmlizedString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(pXmlizedString));
            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
			
        }
    }

    public class root
    {
        public act act { get; set; }
        public root()
        {
            act = new act();
        }
    }
  
   public  class act
    {
       public act()
       {
           actitems = new List<item>();
           actcorrelations = new List<actcorrelation>();
       }
        [XmlAttribute]
        public string actid { get; set; }
        public string actname { get; set; }
        public string fileNumber { get; set; }
        public string pubdate { get; set; }
        public string stadate { get; set; }
        public string depts { get; set; }
        public string deptids { get; set; }
        public string state { get; set; }
        public string opdate { get; set; }
        public string effect { get; set; }
        public string content { get; set; }
        public string enddate { get; set; }
        public List<item> actitems { get; set; }
        public List<actcorrelation> actcorrelations { get; set; }
    }
   public class item
    {
       [XmlAttribute]
        public string itemid { get; set; }
        public string actid { get; set; }
        public string itemname { get; set; }
        public string itemtype { get; set; }
        public string orders { get; set; }
        public string content { get; set; }
        public string itemparentid { get; set; }
    }
   public class actcorrelation
    {
        public string toactid { get; set; }
        public string toitemid { get; set; }
        public string fromactid { get; set; }
        public string fromactname { get; set; }
        public string fromitemid { get; set; }
        public string fromitemcontent { get; set; }
        public string fromitemname { get; set; }
    }
}
