using System;

namespace Stactive
{
    public class StactiveEvent
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        
        private StactiveEvent()
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.UtcNow;
        }

        public StactiveEvent(string name) : this()
        {
            if (string.IsNullOrEmpty(name)) throw new StactiveException("StactiveEvent Name can not be null or empty");
            Name = name;
        }
    }
}