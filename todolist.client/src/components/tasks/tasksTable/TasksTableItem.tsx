import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import ListGroup from "react-bootstrap/ListGroup";
import { stringToFormattedDateString } from "../../../utils/dateUtils";
import {
  deleteTask,
  setTaskOnDeletion,
  toggleTask,
} from "../../../redux/reducers/tasks-slice";
import { Category } from "../../../redux/types/category";
import { Task } from "../../../redux/types/task";

type TaskTableItemProps = {
  task: Task;
  category?: Category;
};

const TasksTableItem = ({ task, category }: TaskTableItemProps) => {
  const taskIdOnDeletion = useAppSelector(
    (state) => state.tasks.taskIdOnDeletion
  );

  const handleTaskDeleteClick = () => {
    if (taskIdOnDeletion) {
      dispatch(deleteTask({ id: taskIdOnDeletion }));
    }
    dispatch(setTaskOnDeletion({ id: task.id }));
  };

  const dispatch = useAppDispatch();

  if (task.id === taskIdOnDeletion) {
    return null;
  }

  return (
    <ListGroup.Item className="d-flex w-100">
      <div className="d-flex align-items-center w-100">
        <div className="d-flex w-100 align-items-center text-align-center">
          <span>
            <input
              type="checkbox"
              onClick={() => dispatch(toggleTask({ id: task.id }))}
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
              onClick={handleTaskDeleteClick}
            />
          </span>
        </div>
      </div>
    </ListGroup.Item>
  );
};

export default TasksTableItem;
