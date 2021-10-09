using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingSchedulingApplication.Data;
using MeetingSchedulingApplication.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingSchedulingApplication.Services.Rooms
{
    public class RoomsService : IRoomsService
    {
        private readonly MeetingSchedulingApplicationDbContext _data;

        public RoomsService(MeetingSchedulingApplicationDbContext data)
            => this._data = data;

        public async Task<IEnumerable<RoomServiceModel>> All()
            => await this._data
                .Rooms
                .Select(r => new RoomServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Capacity = r.Capacity
                })
                .ToListAsync();
    }
}
