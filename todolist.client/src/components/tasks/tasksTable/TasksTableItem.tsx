import { useAppDispatch } from "../../../redux/hooks";
import ListGroup from "react-bootstrap/ListGroup";
import { stringToFormattedDateString } from "../../../utils/dateUtils";
import { deleteTask, toggleTask } from "../../../redux/reducers/tasks-slice";
import { Category } from "../../../redux/types/category";
import { Task } from "../../../redux/types/task";

type TaskTableItemProps = {
  task: Task;
  category?: Category;
};

const TasksTableItem = ({ task, category }: TaskTableItemProps) => {
  const dispatch = useAppDispatch();
  return (
    <ListGroup.Item className="d-flex w-100">
      <div className="d-flex align-items-center w-100">
        <div className="d-flex w-100 align-items-center text-align-center">
          <span>
            <input
              type="checkbox"
              onClick={() => dispatch(toggleTask({ taskId: task.id }))}
              defaultChecked={task.isDone}
              className="form-check-input me-2"
            />
          </span>
          <span className={`w-50 ${task.isDone ? "strike" : ""}`}>
            {task.title}
          </span>
          <span className={`w-50 ${task.isDone ? "strike" : ""}`}>
            {stringToFormattedDateString(task.dueDate)}
          </span>
          <span className={`w-25 ${task.isDone ? "strike" : ""}`}>
            {category?.name || "N/A"}
          </span>
          <span className="w-25 d-flex justify-content-end">
            <input
              type="button"
              value="&#10006;"
              className="btn btn-primary-outline shadow-none "
              onClick={() => dispatch(deleteTask({ taskId: task.id }))}
            />
          </span>
        </div>
      </div>
    </ListGroup.Item>
  );
};

export default TasksTableItem;
