import http from 'k6/http';

export const options = {
    vus: 10,
    duration: '100s',
};

export default function () {
    const url = 'http://localhost:5001/urls';
    const payload = JSON.stringify({
        target: 'https://bytebytego.com'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    http.post(url, payload, params);
}
