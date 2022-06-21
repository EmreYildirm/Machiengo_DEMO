using Machinego_Demo.Models;
using Machinego_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Machinego_Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MachineCategoriesController : Controller
    {
        private IMachineCategoryService machineCategoryService;
        public MachineCategoriesController(IMachineCategoryService machineCategoryService)
        {
            this.machineCategoryService = machineCategoryService;
        }

        [HttpGet("GetMachineCategories")]
        public List<MachineCategory> GetMachineCategories()
        {
            return machineCategoryService.GetMachineCategories();
        }
    }
}
