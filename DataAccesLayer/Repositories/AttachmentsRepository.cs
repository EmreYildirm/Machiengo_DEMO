using System;
using System.Collections.Generic;
using System.Text;
using Machinego_Demo.Models;

namespace Machinego_Demo.DataAccesLayer.Repositories
{
    public class AttachmentsRepository : BaseRepository<Attachment> , IAttachmentsRepository
    {
        public AttachmentsRepository(MachiengoDbContext Context) : base(Context)
        {

        }
    }
}
