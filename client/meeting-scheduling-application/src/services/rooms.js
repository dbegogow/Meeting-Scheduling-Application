import { urlRooms } from '../endpoints';

const getAllRooms = async () => {
    const res = await fetch(urlRooms);
    const rooms = await res.json();

    return rooms;
}