using Machinego_Demo.DataAccesLayer;
using Machinego_Demo.Models;
using System.Collections.Generic;
using System.Linq;
using Machinego_Demo.DataAccesLayer.Repositories;

namespace Machinego_Demo.Services
{
    public interface IMachineTypeService
    {
        public List<MachineType> GetMachineTypesByMachineCategory(int machineCategory);
    }
    public class MachineTypeService : IMachineTypeService
    {
        private readonly IMachineTypeRepository machineTypeRepository;
        public MachineTypeService(IMachineTypeRepository machineTypeRepository)
        {
            this.machineTypeRepository = machineTypeRepository;
        }
        public List<MachineType> GetMachineTypesByMachineCategory(int machineCategory)
        {
            if (machineCategory < 1)
                return null;
            else
                return machineTypeRepository.List(x => x.MachineCategory == machineCategory).ToList();
        }
    }
}
