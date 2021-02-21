using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1.XML
{
    public static class ObjectToXML
    {
        private static readonly Type[] WriteTypes = new[] {
            typeof(string), typeof(DateTime),typeof(decimal), typeof(Guid),
        };
        public static bool IsSimpleType(this Type type)
        {
            return type.IsPrimitive || WriteTypes.Contains(type) || type.IsEnum;
        }
        public static XElement ToXml(this object input)
        {
            return input.ToXml(null);
        }

        private static string GetXMLElementAttributeName(PropertyInfo info)
        {
            string attributeName = "";

            var attr = info.GetCustomAttributes(true);
            if (attr != null && attr.Length > 0)
            {

                foreach (var item in attr)
                {
                    if (item is XmlElementAttribute)
                    {
                        var temp = item as XmlElementAttribute;
                        attributeName = temp.ElementName;


                    }
                    else if (item is XmlRootAttribute)
                    {
                        var temp = item as XmlRootAttribute;
                        attributeName = temp.ElementName;
                    }
                }
            }
            return attributeName;
        }

        private static object GetPropertyValue(object input, PropertyInfo info)
        {
            if (info.PropertyType.IsEnum)
            {
                return (int)info.GetValue(input);
            }
            return info.GetValue(input);
        }

        public static XElement ToXml(this object input, string element)
        {
            if (input == null)
                return null;

            if (string.IsNullOrEmpty(element))
                element = "object";

            element = XmlConvert.EncodeName(element);
            var ret = new XElement(element);

            if (input != null)
            {
                var type = input.GetType();
                var props = type.GetProperties();
                var elements = from prop in props
                               let name = XmlConvert.EncodeName(GetXMLElementAttributeName(prop) == "" ? prop.Name : GetXMLElementAttributeName(prop))
                               let val = GetPropertyValue(input, prop)
                               let value = prop.PropertyType.IsSimpleType()
                                    ? new XElement(name, val)
                                    : val.ToXml(name)
                               where value != null
                               select value;

                ret.Add(elements);
            }

            return ret;
        }


        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            //创建序列化对象
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();
            return str;
        }

        public static string XmlSerialize<T>(T obj)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    Type t = obj.GetType();
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(sw, obj);
                    sw.Close();
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("将实体对象转换成XML异常", ex);
            }
        }


        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch
            {
                throw new Exception("反序列化失败");
            }
        }
    }
}
