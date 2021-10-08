using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingSchedulingApplication.Data.Models
{
    public class Room
    {
        [Required]
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; init; }

        public int Capacity { get; init; }

        public TimeSpan AvailableFrom { get; init; }

        public TimeSpan AvailableTo { get; init; }

        public DateTime Date { get; init; }

        public ICollection<Slot> Schedule { get; init; } = new HashSet<Slot>();
    }
}
