using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingSchedulingApplication.Models
{
    public class SearchSlotsModel
    {
        public string Id { get; init; }

        public DateTime Date { get; init; }

        [RegularExpression(@"^\d\d:\d\d$")]
        public string Duration { get; init; }
    }
}
