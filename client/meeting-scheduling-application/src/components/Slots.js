

const Slots = () => {
    return (
        <div className="slots-container">
            <form>
                <h1>Slots</h1>
                <label for="time">Meeting Time</label>
                <input type="text" id="time" placeholder="12:30-13:30" />
                <button>Search for slots</button>
            </form>
        </div>
    );
};

export default Slots;