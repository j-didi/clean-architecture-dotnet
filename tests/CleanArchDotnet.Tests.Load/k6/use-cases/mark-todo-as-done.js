import http from 'k6/http';
import { sleep, group, check } from 'k6';
import { url } from './todo.js';

export function markTodoAsDone(id) {
    
    group('mark-todo-as-done', function () {
        let response = http.put(`${url}/${id}/MarkTodoAsDone`);
        checkResponse(response);
        sleep(1);
    });
    
}

function checkResponse(response) {
    check(response, {
        'can mark todo as done': (res) => {
            return res.status === 200;
        }
    });
}