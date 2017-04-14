using System;

namespace Stactive.Models
{
    public class RequestLog
    {
        public Guid Id { get; }
        public string Url { get; set; }
        public DateTime DateTime { get; }
        public int ResponseStatus { get; set; }
        public long? ResponseLength { get; set; }
        public long ProcessingTime { get; set; }
        public string ContentType { get; set; }
        public bool Authorized { get; set; }
        public string UserId { get; set; }

        public RequestLog()
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.UtcNow;
        }
    }
}