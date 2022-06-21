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
    public class MachineTypeController : Controller
    {
        private IMachineTypeService machineTypeService;
        public MachineTypeController(IMachineTypeService machineTypeService)
        {
            this.machineTypeService = machineTypeService;
        }
        [HttpGet("GetMachineTypesByMachineCategory/{machineCategory}")]
        public List<MachineType> GetMachineTypesByMachineCategory(int machineCategory)
        {
            return machineTypeService.GetMachineTypesByMachineCategory(machineCategory);
        }
    }
}
