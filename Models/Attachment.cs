using System.Collections.Generic;

namespace Machinego_Demo.Models
{
    public class Attachment : Base
    {
        public int MachineType { get; set; }

        public IList<MachineAttachments> MachineAttachments { get; set; }
    }
}
