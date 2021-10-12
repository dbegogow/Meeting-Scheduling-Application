using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Services.Slots
{
    public interface ISlotsService
    {
        Task<IEnumerable<SlotServiceModel>> EmptySlots(
            string roomId,
            DateTime date,
            TimeSpan duration);
    }
}
