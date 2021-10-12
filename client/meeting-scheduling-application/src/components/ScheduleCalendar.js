import { useState } from 'react';
import 'react-calendar/dist/Calendar.css';
import Calendar from 'react-calendar';

const ScheduleCalendar = ({ setDate }) => {
    return (
        <div>
            <Calendar
                onChange={setDate}
            />
        </div>
    );
};

export default ScheduleCalendar;