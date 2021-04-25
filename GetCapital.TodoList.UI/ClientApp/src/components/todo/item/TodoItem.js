import React, { Component } from 'react';
import { Form, Row, Col, Button } from 'react-bootstrap';
import { TodoList } from '../list/TodoList';

export class TodoItem extends Component {
  static displayName = TodoItem.name;

  constructor (props){
    super(props);

    this.addTodoItem = this.addTodoItem.bind(this);
  }

  addTodoItem(e) {
    console.log(this.txtNewItem.value);

    this.postNewItem(this.txtNewItem.value);
    
    e.preventDefault();
  }

  render () {
    return (
          <form onSubmit={this.addTodoItem}>
            <Row className="justify-content-md-center">
                <Col xs lg="8">
                  <Form.Control 
                    className="mb-2" 
                    name="txtNewItem"
                    id="txtNewTask" 
                    placeholder="New Task"
                    ref={i => (this.txtNewItem = i)} />
                </Col>
                <Col md="auto">
                  <Button className="mb-2" type="submit">
                    Add
                  </Button>
                </Col>
            </Row>
            </form>
    );
  }

  async postNewItem(taskName) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Name: taskName })
    };

    fetch('api/TodoItems', requestOptions)
        .then(response => response.json())
        .then(data => this.setState({ todoItems: data.data, loading: false }));
  }
}
