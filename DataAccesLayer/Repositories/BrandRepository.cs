
using Machinego_Demo.Models;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(MachiengoDbContext context) : base(context)
        {

        }
    }
}
