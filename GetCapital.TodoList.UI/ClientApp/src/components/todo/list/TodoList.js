import React, { Component } from 'react';
import { TodoItem } from '../item/TodoItem';

export class TodoList extends Component {
  static displayName = TodoList.name;

  constructor(props){
      super(props);
      this.state = { todoItems: [], loading: true };
  }

  componentDidMount() {
    this.getTodoList();
  }

  static renderTodoList (todoItems) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>IsCompleted</th>
            </tr>
          </thead>
          <tbody>
            {todoItems.map(item =>
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.isCompleted}</td>
              </tr>
            )}
          </tbody>
        </table>
      );
  }

  render () {
    let contents = this.state.loading
    ? <p><em>Loading...</em></p>
    : TodoList.renderTodoList(this.state.todoItems);

    return (
        <div>
          <h2 id="tabelLabel" >ToDo List</h2>
          <TodoItem />
          {contents}
        </div>
      );
  }

  async getTodoList() {
    const response = await fetch('api/TodoItems');
    const data = await response.json();

    console.log(data.data);
    this.setState({ todoItems: data.data, loading: false });
  }
}
