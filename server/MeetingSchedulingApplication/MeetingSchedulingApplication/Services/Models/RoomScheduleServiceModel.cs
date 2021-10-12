using System;
using System.Collections.Generic;
using MeetingSchedulingApplication.Data.Models;

namespace MeetingSchedulingApplication.Services.Models
{
    public class RoomScheduleServiceModel
    {
        public TimeSpan AvailableFrom { get; init; }

        public TimeSpan AvailableTo { get; init; }

        public IEnumerable<Slot> Schedule { get; init; }
    }
}
