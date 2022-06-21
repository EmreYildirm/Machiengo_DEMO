using Machinego_Demo.Models;
namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public class MachineCategoriesRepository : BaseRepository<MachineCategory>, IMachineCategoriesRepository
    {
        public MachineCategoriesRepository(MachiengoDbContext context) : base(context)
        {

        }

    }
}
