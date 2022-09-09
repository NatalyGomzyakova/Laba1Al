using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Aleks
{
    class Program
    {
        static void ShowXmlNodeData(XmlReader reader)
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    Console.WriteLine("element <{0}>", reader.Name);
                    if (reader.HasAttributes == true)
                    {
                        Console.WriteLine("ATRIBUTS ELEM <{0}>:", reader.Name);
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine("- {0} = {1}", reader.Name, reader.Value);
                        }
                    }
                    break;
                case XmlNodeType.Text: Console.WriteLine("Текст:" + reader.Value); break;
                case XmlNodeType.Comment:
                    Console.WriteLine("Комент:" + reader.Value); break;
                case XmlNodeType.CDATA:
                    Console.WriteLine("Секция cdata:" + reader.Value); break;
            }
        }
        static  void WriteXml(string uri)
        {

            XmlWriterSettings wrSets = new XmlWriterSettings();
            wrSets.Indent = true;
            wrSets.Encoding = Encoding.UTF8;

            XmlWriter writer = XmlWriter.Create(uri, wrSets);
            writer.WriteStartDocument();
            writer.WriteComment("Shoes and price");
            writer.WriteStartElement("shop");
            writer.WriteStartElement("section");
            writer.WriteAttributeString("code", "A", "title", "sport");
            writer.WriteStartElement("shoes");
            writer.WriteAttributeString("code", "Aa1" );
            writer.WriteStartElement("name");
            writer.WriteString("kross");
            writer.WriteEndElement();
                writer.WriteStartElement("Color");
            writer.WriteString("pink");
            writer.WriteEndElement();
            writer.WriteStartElement("price");
            writer.WriteString("1000");
            writer.WriteEndElement();


            writer.WriteStartElement("accessory");
            writer.WriteStartElement("Color");
            writer.WriteString("pink");
            writer.WriteEndElement();
            writer.WriteStartElement("price");
            writer.WriteString("1000");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
            Console.WriteLine("\n \n Записано");
        }
        static void ReadXml(string uri)
        {
            XmlReaderSettings rdSets = new XmlReaderSettings();
            rdSets.IgnoreWhitespace = true;
            rdSets.IgnoreComments = true;

            XmlReader reader = XmlReader.Create(uri, rdSets);
            Console.WriteLine("взято из" + uri);
            try
            {
                while (reader.Read()) ShowXmlNodeData(reader);
            }
            catch(XmlException exc)
            {
                Console.WriteLine("Err" + exc.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Чтение и Запись";
            string uri = @"XML\Shoes.xml";
            ReadXml(uri);
           string newUri = @"XML\newShoes.xml";
            WriteXml(newUri);
            ReadXml(newUri);

            Console.Read();
        }
    }
}
