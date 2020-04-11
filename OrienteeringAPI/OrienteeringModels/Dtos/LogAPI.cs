using System;
using System.Collections.Generic;
using System.Text;

namespace OrienteeringModels.Dtos
{
    public class LogAPI
    {
        // Request
        public int StatusCode { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }
        public DateTime RequestedOn { get; set; }

        // Response
        public string Response { get; set; }
        public DateTime RespondedOn { get; set; }
        public string Exception { get; set; }
    }
}
