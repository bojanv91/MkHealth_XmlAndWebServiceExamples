using Moor.XmlConversionLibrary.XmlToCsvStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MkHealth_XmlAndWebServiceExamples
{
    public static class FileGenerator
    {
        private static string GetOutputPath(string filename)
        {
            return string.Format("{0}/{1}.txt", Directory.GetCurrentDirectory(), filename);
        }

        public static void CreateOutput(ServiceResult serviceResult)
        {
            string filename = serviceResult.Url
                            .Replace("/", "_").Replace(":", "_")
                            .Replace("?", "_").Replace("#", "_")
                            .Replace("%", "_").Replace("&", "_");

            ConvertXmlToCvc(serviceResult.Result);
        }


        public static void ConvertXmlToCvc(string xmlString)
        {
            File.WriteAllText(@"D:\Payslip.xml", xmlString);
            var converter = new XmlToCsvUsingDataSet(@"D:\Payslip.xml");
            var context = new XmlToCsvContext(converter);

            foreach (string xmlTableName in context.Strategy.TableNameCollection)
            {
                context.Execute(xmlTableName, @"D:\" + xmlTableName + ".csv", Encoding.Unicode);
            }
        }
    }
}
