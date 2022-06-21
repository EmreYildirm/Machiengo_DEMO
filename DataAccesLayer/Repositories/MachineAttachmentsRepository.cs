using Machinego_Demo.Models;

namespace Machinego_Demo.DataAccesLayer.Repositories

{
    public class MachineAttachmentsRepository : BaseRepository<MachineAttachments>, IMachineAttachmentsRepository
    {
        public MachineAttachmentsRepository(MachiengoDbContext context) : base(context)
        {

        }
    }
}
