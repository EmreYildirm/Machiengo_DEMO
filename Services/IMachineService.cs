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
        public List<MachineListViewModel> GetByAllMachineList();
    }
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository machineRepository;
        private readonly IMachineAttachmentsRepository machineAttachmentsRepository;
        private readonly IAttachmentsRepository attachmentsRepository;
        private readonly IBrandRepository brandRepository; private readonly IMachineTypeRepository machineTypeRepository; private readonly IMachineCategoriesRepository machineCategoriesRepository;

        public MachineService(IMachineRepository machineRepository, IMachineAttachmentsRepository machineAttachmentsRepository, IAttachmentsRepository attachmentsRepository, IBrandRepository brandRepository, IMachineTypeRepository machineTypeRepository, IMachineCategoriesRepository machineCategoriesRepository)
        {
            this.machineRepository = machineRepository;
            this.machineAttachmentsRepository = machineAttachmentsRepository;
            this.attachmentsRepository = attachmentsRepository;
            this.brandRepository = brandRepository;
            this.machineTypeRepository = machineTypeRepository;
            this.machineCategoriesRepository = machineCategoriesRepository;
        }

        public List<MachineListViewModel> GetByAllMachineList()
        {
            List<MachineListViewModel> machineListViewModels = new List<MachineListViewModel>();
            var machineList = machineRepository.List().ToList();
            foreach (var item in machineList)
            {
                MachineListViewModel machineListViewModel = new MachineListViewModel()
                {
                    Brand = brandRepository.SingleOrDefault(item.Brand)?.Name,
                    MachineCategory = machineCategoriesRepository.SingleOrDefault(item.MachineCategory)?.Name,
                    MachineType = machineTypeRepository.SingleOrDefault(item.MachineType)?.Name,
                    Name = item.Name,
                    Model = item.Model,
                    ProductionYear = item.ProductionYear,
                    Attachments = new List<Attachment>()
                };
                var machAttachs = machineAttachmentsRepository.List(x => x.MachineId == item.Id).ToList();

                foreach (var attach in machAttachs)
                {
                    machineListViewModel.Attachments.Add(attachmentsRepository.SingleOrDefault(attach.AttachmentId));
                }

                machineListViewModels.Add(machineListViewModel);
            }
            return  machineListViewModels;
        }

        public Machine SaveNewMachine(MachineSaveViewModel newMachine)
        {
            try
            {
                machineRepository.BeginTransaction();
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
                machineRepository.Commit();
                return machineResult;
            }
            catch
            {
                machineRepository.Rollback();
                throw new Exception();
            }
        }
    }
}
