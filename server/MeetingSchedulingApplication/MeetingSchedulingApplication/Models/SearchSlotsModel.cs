using System;

namespace MeetingSchedulingApplication.Models
{
    public class SearchSlotsModel
    {
        public string Name { get; init; }

        public DateTime Date { get; init; }

        public TimeSpan Duration { get; init; }
    }
}
