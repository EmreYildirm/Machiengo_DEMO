using Machinego_Demo.Models;
using Machinego_Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Machinego_Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private IBrandService brandService;
        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("GetBrandsByMachineCategory/{machineCategory}")]
        public List<Brand> GetBrandsByMachineCategory(int machineCategory)
        {
            return brandService.GetBrandsByMachineCategory(machineCategory);
        }
    }
}
