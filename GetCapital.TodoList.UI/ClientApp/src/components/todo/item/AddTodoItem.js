import { Form, Row, Col, Button } from 'react-bootstrap';
import { useState } from 'react';

const AddTodoItem = ({ addTaskToList }) => {
    const [todoItem, setTodoListItem] = useState("");
    const onSubmit = (e) => {
        e.preventDefault();

        if(!todoItem){
            alert("Task name is required!");
            return;
        }

        addTaskToList({ todoItem: todoItem });

        setTodoListItem("");
    }

    return (
        <form onSubmit={onSubmit}>
            <Row className="justify-content-md-center">
                <Col md="8" xs="10">
                  <Form.Control 
                    className="mb-2" 
                    placeholder="New Task"
                    value={todoItem}
                    onChange={(e) => setTodoListItem(e.target.value)} />
                </Col>
                <Col xs="auto">
                  <Button className="mb-2" type="submit">
                    Add
                  </Button>
                </Col>
            </Row>
        </form>
    )
}

export default AddTodoItem;