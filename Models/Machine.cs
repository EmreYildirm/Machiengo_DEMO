using System;
using System.Collections.Generic;

namespace Machinego_Demo.Models
{
    public class Machine: Base
    {
        public int MachineCategory { get; set; }
        public int MachineType { get; set; }
        public int Brand { get; set; }
        public string Model { get; set; }
        public DateTime ProductionYear { get; set; }
        public IList<MachineAttachments> MachineAttachments { get; set; }
    }
}
