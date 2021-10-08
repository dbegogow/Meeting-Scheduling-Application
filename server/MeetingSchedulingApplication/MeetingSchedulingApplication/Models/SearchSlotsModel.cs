using System;

namespace MeetingSchedulingApplication.Models
{
    public class SearchSlotsFormModel
    {
        public string Name { get; init; }

        public DateTime Date { get; init; }

        public TimeSpan Duration { get; init; }
    }
}
