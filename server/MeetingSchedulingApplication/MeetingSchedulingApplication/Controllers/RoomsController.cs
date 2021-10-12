using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MeetingSchedulingApplication.Services.Rooms;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _rooms;

        public RoomsController(IRoomsService rooms)
            => this._rooms = rooms;

        [HttpGet]
        public async Task<ActionResult<List<RoomServiceModel>>> Get()
        {
            var rooms = await this._rooms
                .All();

            return rooms.ToList();
        }
    }
}
