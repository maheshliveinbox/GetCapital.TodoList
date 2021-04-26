import { Col, Row } from "reactstrap";
import { ListGroupItem } from "reactstrap";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrash } from "@fortawesome/free-solid-svg-icons";

const TodoItem = ({ todoItem, onComplete, onDelete }) => {
    return (
            <ListGroupItem>
                <Row>
                    <Col xs="1" className="text-center">
                        <input 
                            type="checkbox" 
                            onChange={() => onComplete(todoItem.id)} 
                            checked={todoItem.isCompleted} ></input>
                    </Col>
                    <Col className={todoItem.isCompleted ? "text-left strikethrough" : "text-left"}>{todoItem.name}</Col>
                    <Col xs="1" className="deleteIcon">
                        <FontAwesomeIcon 
                            icon={faTrash} 
                            onClick={() => onDelete(todoItem.id)} />
                    </Col>
                </Row>
            </ListGroupItem>
    )
}

export default TodoItem;