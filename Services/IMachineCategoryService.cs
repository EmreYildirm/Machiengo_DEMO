using Machinego_Demo.DataAccesLayer;
using Machinego_Demo.Models;
using System.Collections.Generic;
using System.Linq;
using Machinego_Demo.DataAccesLayer.Repositories;

namespace Machinego_Demo.Services
{
    public interface IMachineCategoryService
    {
        public List<MachineCategory> GetMachineCategories();
    }
    public class MachineCategoryService : IMachineCategoryService
    {
        private readonly IMachineCategoriesRepository machineCategoriesRepository;
        public MachineCategoryService(IMachineCategoriesRepository machineCategoriesRepository)
        {
            
            this.machineCategoriesRepository = machineCategoriesRepository;
        }
        public List<MachineCategory> GetMachineCategories()
        {
            return machineCategoriesRepository.List().ToList();
        }
    }
}
