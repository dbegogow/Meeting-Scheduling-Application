using System;

namespace MeetingSchedulingApplication.Data.Models
{
    public class Slot
    {
        public TimeSpan From { get; init; }

        public TimeSpan To { get; init; }

        public Room Room { get; init; }
    }
}
