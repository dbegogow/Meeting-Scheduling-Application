using System;

namespace MeetingSchedulingApplication.Data.Models
{
    public class Slot
    {
        public int Id { get; init; }

        public TimeSpan From { get; init; }

        public TimeSpan To { get; init; }

        public DateTime Date { get; init; }

        public Room Room { get; init; }
    }
}
