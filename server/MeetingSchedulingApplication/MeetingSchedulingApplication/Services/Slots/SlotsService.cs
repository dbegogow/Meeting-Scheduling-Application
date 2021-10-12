using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MeetingSchedulingApplication.Data;
using MeetingSchedulingApplication.Services.Models;

namespace MeetingSchedulingApplication.Services.Slots
{
    public class SlotsService : ISlotsService
    {
        private readonly MeetingSchedulingApplicationDbContext _data;

        public SlotsService(MeetingSchedulingApplicationDbContext data)
            => this._data = data;

        public async Task<IEnumerable<SlotServiceModel>> EmptySlots(
            string roomId,
            DateTime date,
            TimeSpan duration)
        {
            var room = await this._data
                .Rooms
                .Where(r => r.Id == roomId)
                .Select(r => new RoomScheduleServiceModel
                {
                    AvailableFrom = r.AvailableFrom,
                    AvailableTo = r.AvailableTo,
                    Schedule = r.Schedule
                })
                .FirstOrDefaultAsync();

            if (room == null)
            {
                return null;
            }

            var emptySlots = new List<SlotServiceModel>();

            for (int hours = room.AvailableFrom.Hours; hours < room.AvailableTo.Hours - (duration.Hours + duration.Minutes == 0 ? 0 : 2); hours++)
            {
                for (int minutes = 15; minutes <= 45; minutes += 15)
                {
                    var now = new TimeSpan(hours, minutes, 0);
                    var currentMeeting = now + duration;

                    if (room.Schedule.Any(s =>
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
