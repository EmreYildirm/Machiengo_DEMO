using Machinego_Demo.Models;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public class MachineTypeRepository : BaseRepository<MachineType>, IMachineTypeRepository
    {
        public MachineTypeRepository(MachiengoDbContext context) : base(context)
        {

        }
    }
}
