import http from 'k6/http';
import { sleep, group, check } from 'k6';
import { url } from './todo.js';

export function getTodoById(id) {
    
    group('get-todo-by-id', function () {
        let response = http.get(`${url}/${id}`);
        checkResponse(response);
        sleep(1);
    });
    
}

function checkResponse(response) {
    check(response, {
        'can get todo by id': (res) => {
            let result = JSON.parse(res.body);
            return res.status === 200 && result !== undefined;
        }
    });
}