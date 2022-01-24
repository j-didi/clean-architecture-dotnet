import http from 'k6/http';
import { sleep, group, check } from 'k6';
import { url } from './todo.js';

export function deleteTodo(id) {
    
    group('delete-todo', function () {
        let response = http.del(`${url}/${id}`);
        checkResponse(response);
        sleep(1);
    });
    
}

function checkResponse(response) {
    check(response, {
        'can delete todo': (res) => {
            return res.status === 200;
        }
    });
}