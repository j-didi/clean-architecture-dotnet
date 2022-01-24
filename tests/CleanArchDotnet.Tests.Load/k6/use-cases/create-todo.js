import http from 'k6/http';
import { sleep, group, check } from 'k6';
import { url } from './todo.js';

let todoId;

export function createTodo() {
    
    group('create-todo', function () {
        let response = http.post(url, getPayload(), getParams());
        checkResponse(response);
        sleep(1);
    });
    
    return todoId;
}

function getParams() {
    return { headers: { 'Content-Type': 'application/json' } };
}

function getPayload() {
    return JSON.stringify({description: 'Creating a TODO' });
}

function checkResponse(response) {
    
    check(response, {
        'can create todo': (res) => res.status === 200,
        'can obtain todo id': (res) => {
            response = JSON.parse(res.body);
            todoId = response.id
            return todoId !== undefined;
        }
    });
}