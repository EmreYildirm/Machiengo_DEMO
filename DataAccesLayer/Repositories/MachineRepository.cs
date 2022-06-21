using Machinego_Demo.Models;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public class MachineRepository : BaseRepository<Machine>, IMachineRepository
    {
        public MachineRepository(MachiengoDbContext context) : base(context)
        {

        }
    }
}
