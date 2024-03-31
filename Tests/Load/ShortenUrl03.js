import http from 'k6/http';

export const options = {
    vus: 100,
    duration: '100s',
};

export default function () {
    const url = 'http://localhost:5003/api/urls';
    const payload = JSON.stringify({
        target: 'https://bytebytego.com/courses/system-design-interview/design-a-url-shortener'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    http.post(url, payload, params);
}
