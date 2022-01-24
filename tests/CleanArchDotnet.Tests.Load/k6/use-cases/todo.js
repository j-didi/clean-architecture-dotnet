import {createTodo} from './create-todo.js';
import {getTodos} from "./get-todos.js";
import {getTodoById} from "./get-todo-by-id.js";
import {markTodoAsDone} from "./mark-todo-as-done.js";
import {deleteTodo} from "./delete-todo.js";

export const options = { vus: 10, duration: '5s' }
export var url = 'http://host.docker.internal:5011/Todo';

export default function () {
  let id = createTodo();
  getTodos();
  getTodoById(id);
  markTodoAsDone(id);
  deleteTodo(id);
} 