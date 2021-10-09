import { useEffect, useState } from 'react';
import { Route, Switch } from 'react-router-dom';
import ScheduleCalendar from './components/ScheduleCalendar';
import { getAllRooms } from './services/roomsService';
import Room from './components/Room';
import Slots from './components/Slots';

const App = () => {
    const [rooms, setRooms] = useState([]);

    useEffect(() => {
        getAllRooms()
            .then(rooms => setRooms(rooms));
    }, [rooms]);

    return (
        <div className="app">
            <Switch>
                <Route exact path="/">
                    <h1>Select a Date and Room</h1>
                    <ScheduleCalendar />
                    <div className="rooms-container">
                        {
                            rooms?.map(room =>
                                <Room
                                    key={room.id}
                                    id={room.id}
                                    name={room.name}
                                    capacity={room.capacity}
                                />)
                        }
                    </div>
                </Route>
                <Route path="/slots">
                    <Slots />
                </Route>
            </Switch>
        </div>
    );
};

export default App;