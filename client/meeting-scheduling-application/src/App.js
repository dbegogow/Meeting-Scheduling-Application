import { Route, Switch } from 'react-router-dom';
import ScheduleCalendar from './components/ScheduleCalendar';
import Room from './components/Room';
import Slots from './components/Slots';

const App = () => {
    return (
        <div className="app">
            <Switch>
                <Route exact path="/">
                    <h1>Select a Date and Room</h1>
                    <ScheduleCalendar />
                    <div className="rooms-container">
                        <Room></Room>
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