using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MkHealth_XmlAndWebServiceExamples
{
    public class ServiceResult
    {
        public string Result { get; private set; }
        public string Url { get; private set; }
        public string StatusMessage { get; private set; }

        public ServiceResult(string result, string url, string statusMessage)
        {
            Result = result;
            Url = url;
            StatusMessage = statusMessage;
        }
    }
}
