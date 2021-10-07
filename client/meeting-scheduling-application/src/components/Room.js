import { Link } from "react-router-dom";

const Room = () => {
    return (
        <Link to="/slots" className="room">
            <span>
                <span>Name: </span>
                Iskar
            </span>
            <span>
                <span>Capacity: </span>
                8
            </span>
        </Link>
    );
};

export default Room;