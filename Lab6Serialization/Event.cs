using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Serialization
{
    internal class Event
    {
        public int Version { get; set; }
        public int EventNumber { get; set; }
        public string Location { get; set; }
        public Event(int eventNumber, string location) 
        { 
            this.Version = 1;
            this.EventNumber = eventNumber;
            this.Location = location;
        }
    }
}
