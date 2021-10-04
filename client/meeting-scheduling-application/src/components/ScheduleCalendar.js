import { useState } from 'react';
import 'react-calendar/dist/Calendar.css';
import Calendar from 'react-calendar';

const ScheduleCalendar = () => {
    const [date, setDate] = useState(new Date());

    return (
        <div>
            <Calendar
                onChange={setDate}
                value={date}
            />
        </div>
    );
};

export default ScheduleCalendar;