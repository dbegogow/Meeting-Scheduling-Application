using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MeetingSchedulingApplication.Data;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Services
{
    public class SlotsService : ISlotsService
    {
        private readonly MeetingSchedulingApplicationDbContext _data;

        public SlotsService(MeetingSchedulingApplicationDbContext data)
            => this._data = data;

        public async Task<IEnumerable<SlotServiceModel>> EmptySlots(
            string roomName,
            DateTime date,
            TimeSpan duration)
        {
            var room = await this._data
                .Rooms
                .FirstOrDefaultAsync(r => r.Name == roomName && r.Date == date);

            if (room == null)
            {
                return null;
            }

            var schedule = room.Schedule;

            var emptySlots = new List<SlotServiceModel>();

            for (int hours = room.AvailableFrom.Hours; hours < room.AvailableTo.Hours; hours++)
            {
                for (int minutes = 15; minutes <= 45; minutes += 15)
                {
                    var now = new TimeSpan(hours, minutes, 0);
                    var currentMeeting = now + duration;

                    if (schedule.Any(s =>
                            s.From <= currentMeeting &&
                            s.To >= currentMeeting))
                    {
                        continue;
                    }

                    emptySlots.Add(new SlotServiceModel { AvailableFrom = now });
                }
            }

            return emptySlots;
        }
    }
}
