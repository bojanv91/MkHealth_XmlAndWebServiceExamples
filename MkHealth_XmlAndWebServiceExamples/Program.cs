using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moor.XmlConversionLibrary.XmlToCsvHelpers;
using Moor.XmlConversionLibrary.XmlToCsvStrategy;
using System.Xml.Linq;

namespace MkHealth_XmlAndWebServiceExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program.Start");
            PostExample_newreferral();
            PostExample_nestedRecords();
            
            Console.WriteLine("Program.End");
            Console.Read();
        }

        private static void PostExample_nestedRecords()
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var rootElement = new XElement("records");
            rootElement.Add(new XElement("first_name", "Name"));
            rootElement.Add(new XElement("last_name", "Surename"));
            rootElement.Add(new XElement("middle_name", ""));
            
            var listOf_ambulance_records = new XElement("ambulance_records");
            //ambulance_record 1
            var ambulance_record1 = new XElement("ambulance_record");
            ambulance_record1.Add(new XElement("podatok1", "vrednsot na podatok1"));
            ambulance_record1.Add(new XElement("podatok2", "vrednsot na podatok2"));
            ambulance_record1.Add(new XElement("podatok3", "vrednsot na podatok3"));
            
            var listOf_mkb10_codes = new XElement("mkb10_codes");
            var mkb10_code1 = new XElement("mkb10_code");
            mkb10_code1.Add(new XElement("code_name", "dasdsds"));
            mkb10_code1.Add(new XElement("numero", "15"));
            listOf_mkb10_codes.Add(mkb10_code1);

            var mkb10_code2 = new XElement("mkb10_code");
            mkb10_code2.Add(new XElement("code_name", "dasdsds"));
            mkb10_code2.Add(new XElement("numero", "15"));
            listOf_mkb10_codes.Add(mkb10_code2);

            var mkb10_code3 = new XElement("mkb10_code");
            mkb10_code3.Add(new XElement("code_name", "dasdsds"));
            mkb10_code3.Add(new XElement("numero", "15"));
            listOf_mkb10_codes.Add(mkb10_code3);

            ambulance_record1.Add(listOf_mkb10_codes);
            
            //end ambulance_record 1
            listOf_ambulance_records.Add(ambulance_record1);

            rootElement.Add(listOf_ambulance_records);
            rootElement.Add(new XElement("physician_fascimile", "228876"));
            rootElement.Add(new XElement("referral_type_id", "1"));
            rootElement.Add(new XElement("from", "09:20:00 05-12-2012"));
            rootElement.Add(new XElement("to", "09:40:00 05-12-2012"));

            xDoc.Add(rootElement);

            //ServiceResult result = ServiceCalls.Post(@"https://api.zdravstvo.gov.mk/rest/referrals/newreferral", xDoc);

            //Console.WriteLine(result.StatusMessage);
            //Console.WriteLine(result.Url);
            //Console.WriteLine(result.Result);
            Console.WriteLine(xDoc.ToString());
            Console.WriteLine("-----------------------");
        }

        private static void PostExample_newreferral()
        {
            XDocument xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var rootElement = new XElement("newreferral");
            rootElement.Add(new XElement("embg", "1507987440024"));
            rootElement.Add(new XElement("first_name", "Name"));
            rootElement.Add(new XElement("last_name", "Surename"));
            rootElement.Add(new XElement("middle_name", ""));
            rootElement.Add(new XElement("health_id", "1507987440024"));
            rootElement.Add(new XElement("medic_facsimile", "123456"));
            rootElement.Add(new XElement("mkb10_service", "L70.5"));
            rootElement.Add(new XElement("additional_mkb10_service", "A00.1"));
            rootElement.Add(new XElement("additional_mkb10_service", "A00.9"));
            rootElement.Add(new XElement("referral_desc", "test referral description"));
            rootElement.Add(new XElement("physician_fascimile", "228876"));
            rootElement.Add(new XElement("referral_type_id", "1"));
            rootElement.Add(new XElement("from", "09:20:00 05-12-2012"));
            rootElement.Add(new XElement("to", "09:40:00 05-12-2012"));
            xDoc.Add(rootElement);

            //ServiceResult result = ServiceCalls.Post(@"https://api.zdravstvo.gov.mk/rest/referrals/newreferral", xDoc);

            //Console.WriteLine(result.StatusMessage);
            //Console.WriteLine(result.Url);
            //Console.WriteLine(result.Result);
            Console.WriteLine(xDoc.ToString());
            Console.WriteLine("-----------------------");
        }
    }
}
