using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Services
{
    public interface ISlotsService
    {
        Task<IEnumerable<SlotServiceModel>> EmptySlots(
            string roomName,
            DateTime date,
            TimeSpan duration);
    }
}
