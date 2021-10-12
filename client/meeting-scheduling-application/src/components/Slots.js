import { useState } from 'react';
import { useParams } from 'react-router';
import { getSlots } from '../services/slotsService';

const Slots = ({ date }) => {
    const [slots, setSlots] = useState([]);

    const params = useParams();

    const serachSlots = async (e) => {
        e.preventDefault();

        const target = e.target;

        const id = params.id;
        const duration = target.duration.value;

        await getSlots(id, duration, date)
            .then(slots => setSlots(slots));
    };

    return (
        <div className="slots-container">
            <form onSubmit={serachSlots}>
                <h1>Slots</h1>
                <label htmlFor="duration">Meeting Duration</label>
                <input type="text" id="duration" name="duration" placeholder="1:30" />
                <button>Search for slots</button>
            </form>
            <div className="slots">
                {
                    slots?.map((s, index) =>
                        <button key={index}>{`${s.availableFrom.hours}:${s.availableFrom.minutes}`}</button>)
                }
            </div>
        </div >
    );
};

export default Slots;