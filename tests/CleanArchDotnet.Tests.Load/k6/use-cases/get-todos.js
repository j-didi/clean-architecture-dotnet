import http from 'k6/http';
import { sleep, group, check } from 'k6';
import {url} from "./todo.js";

export function getTodos() {
    
    group('get-todos', function () {
        let response = http.get(url);
        checkResponse(response);
        sleep(1);
    });
    
}

function checkResponse(response) {
    check(response, {
        'can get todos': (res) => {
            let result = JSON.parse(res.body);
            return res.status === 200 && result !== undefined;
        }
    });
}

