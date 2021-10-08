using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeetingSchedulingApplication.Models;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Controllers
{
    [Route("api/slots")]
    public class SlotsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlotServiceModel>>> Get([FromForm] SearchSlotsFormModel searchSlots)
        {

        }
    }
