using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace MkHealth_XmlAndWebServiceExamples
{
    public class ServiceCalls
    {
        public static ServiceResult Get(string url, List<KeyValuePair<string, string>> queryStringPairs = null)
        {
            WebRequest request;
            WebResponse response;
            StreamReader reader;
            StringBuilder valuesSB = new StringBuilder();
            string result = "";
            string postUrl = url;

            if (queryStringPairs != null)
            {
                valuesSB.Append("?");
                foreach (var pair in queryStringPairs)
                    valuesSB.AppendFormat("{0}={1}&", pair.Key, pair.Value);

                string temp = valuesSB.ToString();
                postUrl += temp.Remove(temp.Length - 1);
            }

            request = WebRequest.Create(postUrl);
            request.Method = "GET";

            try
            {
                using (response = request.GetResponse())
                {
                    reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd().Trim();
                }

                return new ServiceResult(result, postUrl, "Success");
            }
            catch (Exception ex)
            {
                return new ServiceResult("Error", postUrl, ex.Message);
            }
        }


        public static ServiceResult Post(string url, XDocument xmlDocument)
        {
            WebRequest request;
            StreamReader reader;
            StringBuilder valuesSB = new StringBuilder();
            string webResponseResult = "";
            string requestXmlData = xmlDocument.ToString();

            request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/xml";

            try
            {
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.WriteLine(requestXmlData);
                }

                using (WebResponse response = request.GetResponse())
                {
                    reader = new StreamReader(response.GetResponseStream());
                    webResponseResult = reader.ReadToEnd().Trim();
                }

                return new ServiceResult(webResponseResult, url, "Success");
            }
            catch (WebException webEx)
            {
                reader = new StreamReader(webEx.Response.GetResponseStream());
                webResponseResult = reader.ReadToEnd().Trim();
                return new ServiceResult(webResponseResult, url, "Error");
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex.Message, url, "Error");
            }
        }
    }
}
