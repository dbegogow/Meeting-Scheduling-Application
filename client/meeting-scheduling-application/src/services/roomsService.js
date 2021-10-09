import { urlRooms } from '../endpoints';

export const getAllRooms = () => {
    return fetch(urlRooms)
        .then(res => res.json())
        .catch(() => alert('Failed to load resources.'));
};