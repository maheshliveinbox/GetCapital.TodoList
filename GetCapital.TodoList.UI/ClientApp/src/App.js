import { useState, useEffect } from 'react'
import { Container } from 'reactstrap';
import Header from './components/Header';
import AddTodoItem from './components/todo/item/AddTodoItem';
import TodoList from './components/todo/list/TodoList';

const App = () => {
  const [todoList, setTodoList] = useState([]);

  useEffect(() => {
    const getTodoList = async () => {
      const todoListFromServer = await fetchTodoList();
      setTodoList(todoListFromServer.data);
    }

    getTodoList();
  }, [])

  const fetchTodoList = async () => {
    const response = await fetch('api/TodoItems');
    const data = await response.json();

    return data;
  }

  const AddTodo = (e) => {
    postNewItem(e.todoItem);
  }

  const postNewItem = async (todoItem) => {
    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ Name: todoItem })
    };

    const res = await fetch('api/TodoItems', requestOptions);
    const data = await res.json();
    
    setTodoList(data.data);
  }

  const deleteTask = async (id) => {
    const res = await fetch(`api/TodoItems/${id}`, {
      method: "DELETE"
    });
    const data = await res.json();
    
    if(data.success)
      setTodoList(data.data) 
    else
      alert('Error deleting task!');
  }

  const togleTask = async (id) => {
    const res = await fetch(`api/TodoItems/${id}`, {
      method: "PUT"
    });
    const data = await res.json();

    if(data.success)
      setTodoList(data.data) 
    else
      alert('Error toggling task!');
  }

  return (
      <Container>
        <Header />
        <AddTodoItem addTaskToList={AddTodo} />
        {todoList.length > 0 ? (
          <TodoList 
            todoList={todoList}
            onComplete={togleTask}
            onDelete={deleteTask} />
            ) : (
              <p>No tasks to show!</p>
            )}
      </Container>
  )
}

export default App;
