const Slots = () => {
    return (
        <div className="slots-container">
            <form>
                <h1>Slots</h1>
                <label for="time">Meeting Duration</label>
                <input type="text" id="time" placeholder="01:30" />
                <button>Search for slots</button>
            </form>
            <div className="slots">
                <button>12:30</button>
                <button>12:30</button>
                <button>12:30</button>
                <button>12:30</button>
                <button>12:30</button>
                <button>12:30</button>
                <button>12:30</button>
            </div>
        </div>
    );
};

export default Slots;