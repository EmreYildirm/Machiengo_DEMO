using Machinego_Demo.Models;
using Machinego_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Machinego_Demo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AttachmentsController : Controller
    {
        private IAttachmentService attachmentsService;
        public AttachmentsController(IAttachmentService attachmentsService)
        {
            this.attachmentsService = attachmentsService;
        }

        [HttpGet("GetAttachmentsByMachineType/{machineTypeId}")]
        public List<Attachment> GetAttachmentsByMachineType(int machineTypeId)
        {
            return attachmentsService.GetAttachmentsByMachineType(machineTypeId);
        }
    }
}
