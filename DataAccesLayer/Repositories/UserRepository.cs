using Machinego_Demo.Models;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MachiengoDbContext context) : base(context)
        {

        }
    }
}
