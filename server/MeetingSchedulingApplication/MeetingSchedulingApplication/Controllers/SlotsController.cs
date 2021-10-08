using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeetingSchedulingApplication.Models;
using MeetingSchedulingApplication.Services;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Controllers
{
    [Route("api/slots")]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotsService _slots;

        public SlotsController(ISlotsService slots)
            => this._slots = slots;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlotServiceModel>>> Get([FromForm] SearchSlotsModel searchSlots)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var emptySlots = await this._slots
                .EmptySlots(searchSlots.Name, searchSlots.Date, searchSlots.Duration);

            if (emptySlots == null)
            {
                return NotFound();
            }

            return emptySlots.ToList();
        }
    }
}