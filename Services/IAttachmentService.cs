using Machinego_Demo.DataAccesLayer;
using Machinego_Demo.DataAccesLayer.Repositories;
using Machinego_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Machinego_Demo.Services
{
    public interface IAttachmentService
    {
        public List<Attachment> GetAttachmentsByMachineType(int machineTypeId);
    }
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentsRepository attachmentsRepository;
        public AttachmentService(IAttachmentsRepository attachmentsRepository)
        {
            this.attachmentsRepository = attachmentsRepository;
        }

        public List<Attachment> GetAttachmentsByMachineType(int machineTypeId)
        {
            if (machineTypeId < 1)
            {
                return null;
            }
            else
            {
                var list = attachmentsRepository.List(x => x.MachineType == machineTypeId);
                return list.ToList();
            }
            
        }
    }
}
