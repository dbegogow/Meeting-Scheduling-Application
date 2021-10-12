import { urlSlots } from '../endpoints';

export const getSlots = (id, duration, date) => {
    return fetch(urlSlots, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id, duration, date })
    })
        .then(res => res.json())
        .catch(() => alert('Failed to load resources.'));
};