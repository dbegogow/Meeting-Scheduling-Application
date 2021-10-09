import { Link } from "react-router-dom";

const Room = ({
    id,
    name,
    capacity
}) => {
    return (
        <Link to={`/slots/${id}}`} className="room">
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