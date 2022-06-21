using Machinego_Demo.DataAccesLayer;
using Machinego_Demo.Models;
using System.Collections.Generic;
using System.Linq;
using Machinego_Demo.DataAccesLayer.Repositories;
using System;

namespace Machinego_Demo.Services
{
    public interface IMachineService
    {
        public Machine SaveNewMachine(MachineSaveViewModel newMachine);
        public List<Machine> GetByAllMachineList();
    }
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository machineRepository;
        private readonly IMachineAttachmentsRepository machineAttachmentsRepository;
        public MachineService(IMachineRepository machineRepository, IMachineAttachmentsRepository machineAttachmentsRepository)
        {
            this.machineRepository = machineRepository;
            this.machineAttachmentsRepository = machineAttachmentsRepository;
        }

        public List<Machine> GetByAllMachineList()
        {
            return machineRepository.List().ToList();
        }

        public Machine SaveNewMachine(MachineSaveViewModel newMachine)
        {
            try
            {
                var machine = new Machine()
                {
                    Name = newMachine.Name,
                    Brand = newMachine.Brand,
                    MachineCategory = newMachine.MachineCategory,
                    MachineType = newMachine.MachineType,
                    Model = newMachine.Model,
                    ProductionYear = newMachine.ProductionYear
                };
                var machineResult = machineRepository.Add(machine);

                foreach (var item in newMachine.Attachments)
                {
                    machineAttachmentsRepository.Add(new MachineAttachments()
                    {
                        AttachmentId = item,
                        MachineId = machine.Id
                    });
                }
                return machineResult;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
