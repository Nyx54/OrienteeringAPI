using System;
using System.ComponentModel.DataAnnotations;

namespace OrienteeringModels.Dtos
{
    public class LogAPI
    {
        // Request
        [Required]
        public long Id { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }
        public DateTime RequestedOn { get; set; }

        // Response
        public string Response { get; set; }
        public DateTime? RespondedOn { get; set; }
        public int? StatusCode { get; set; }
        public string Exception { get; set; }
    }
}
