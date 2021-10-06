import ScheduleCalendar from './components/ScheduleCalendar';
import Room from './components/Room';

const App = () => {
    return (
        <div className="app">
            <h1>Select a Date and Room</h1>
            <ScheduleCalendar />
            <div className="rooms-container">
                <Room></Room>
            </div>
        </div>
    );
};

export default App;