using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MeetingSchedulingApplication.Data
{
    public class MeetingSchedulingApplicationDbContext : DbContext
    {
        public MeetingSchedulingApplicationDbContext([NotNull] DbContextOptions options)
            : base(options)
        {

        }
    }
}
