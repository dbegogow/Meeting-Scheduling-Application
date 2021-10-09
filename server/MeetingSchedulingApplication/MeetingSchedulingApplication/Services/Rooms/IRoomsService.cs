using System.Threading.Tasks;
using System.Collections.Generic;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Services.Rooms
{
    public interface IRoomsService
    {
        Task<IEnumerable<RoomServiceModel>> All();
    }
}
