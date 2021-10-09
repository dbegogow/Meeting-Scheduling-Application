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
                {name}
            </span>
            <span>
                <span>Capacity: </span>
                {capacity}
            </span>
        </Link>
    );
};

export default Room;