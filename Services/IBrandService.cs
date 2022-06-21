using Machinego_Demo.DataAccesLayer;
using Machinego_Demo.Models;
using System.Collections.Generic;
using System.Linq;
using Machinego_Demo.DataAccesLayer.Repositories;

namespace Machinego_Demo.Services
{
    public interface IBrandService 
    {
        public List<Brand> GetBrandsByMachineCategory(int machineCategory);
    }
    public class BrandService :  IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {

            this.brandRepository = brandRepository;
        }
        public List<Brand> GetBrandsByMachineCategory(int machineCategory)
        {
            if (machineCategory < 1)
                return null;
            else
                return brandRepository.List(x => x.MachineCategory == machineCategory).ToList();
        }
    }
}
