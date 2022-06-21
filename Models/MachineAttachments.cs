namespace Machinego_Demo.Models
{
    public class MachineAttachments
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
    }
}
