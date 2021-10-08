using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MeetingSchedulingApplication.Data.Models;

namespace MeetingSchedulingApplication.Data
{
    public class MeetingSchedulingApplicationDbContext : DbContext
    {
        public MeetingSchedulingApplicationDbContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; init; }

        public DbSet<Slot> Schedule { get; init; }
    }
}
