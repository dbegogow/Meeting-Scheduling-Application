using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeetingSchedulingApplication.Models;
using MeetingSchedulingApplication.Services.Slots;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Controllers
{
    [Route("api/slots")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotsService _slots;

        public SlotsController(ISlotsService slots)
            => this._slots = slots;

        [HttpPost]
        public async Task<ActionResult<List<SlotServiceModel>>> Get(SearchSlotsModel searchSlots)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var durationArr = searchSlots.Duration
                .Split(":")
                .Select(int.Parse)
                .ToArray();

            var duration = new TimeSpan(durationArr[0], durationArr[1], 0);

            var emptySlots = await this._slots
                .EmptySlots(searchSlots.Id, searchSlots.Date, duration);

            if (emptySlots == null)
            {
                return NotFound();
            }

            return emptySlots.ToList();
        }
    }
}