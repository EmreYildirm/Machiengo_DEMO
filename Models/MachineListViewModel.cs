using System;
using System.Collections.Generic;

namespace Machinego_Demo.Models
{
    public class MachineListViewModel : Base
    {
        public string MachineCategory { get; set; }
        public string MachineType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionYear { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
