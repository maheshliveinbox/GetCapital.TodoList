import { ListGroup } from "reactstrap";
import TodoItem from "../item/TodoItem";

const TodoList = ({ todoList, onComplete, onDelete }) => {
    return (
        <ListGroup>
            {todoList.map(item =>
                    <TodoItem 
                        key={item.id} 
                        todoItem={item}
                        onComplete={onComplete}
                        onDelete={onDelete} />
                )}
        </ListGroup>
    )
}

export default TodoList;