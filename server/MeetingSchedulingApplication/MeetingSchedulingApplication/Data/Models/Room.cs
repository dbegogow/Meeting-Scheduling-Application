using System;
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
    }
}
