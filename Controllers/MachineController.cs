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
    public class MachineController : Controller
    {
        private IMachineService machineService;
        public MachineController(IMachineService machineService)
        {
            this.machineService = machineService;
        }

        [HttpGet]
        [Route("ListForView")]
        public List<MachineListViewModel> GetByAllMachineList()
        {
           return machineService.GetByAllMachineList();
        } 
        [HttpPost]
        [Route("SaveNewMachine")]
        public Machine SaveNewMachine(MachineSaveViewModel newMachine)
        {
            return machineService.SaveNewMachine(newMachine);
        } 
    }
}
