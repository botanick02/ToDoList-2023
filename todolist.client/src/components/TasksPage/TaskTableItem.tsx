import { useAppDispatch } from "../../app/hooks";
import { deleteTask, toggleTask } from "../../features/tasks/tasks-slice";
import { ICategory, ITask } from "../../features/tasks/types";
import ListGroup from "react-bootstrap/ListGroup";

interface ITaskTableItemProps {
  task: ITask;
  category?: ICategory;
}

const TaskTableItem = (props: ITaskTableItemProps) => {
  const { task, category } = props;
  const dispatch = useAppDispatch();
  return (
    <ListGroup.Item key={task.id} className="d-flex w-100">
      <div className="d-flex align-items-center w-100">
        <div className="d-flex w-100 align-items-center text-align-center">
          <span>
            <input
              type="checkbox"
              onClick={() => dispatch(toggleTask(task.id))}
              defaultChecked={task.isDone}
              className="form-check-input me-2"
            />
          </span>

          <span className={`w-50 ${task.isDone ? "strike" : ""}`}>
            {task.title}
          </span>
          <span className={`w-50 ${task.isDone ? "strike" : ""}`}>
            {task.dueDate}
          </span>
          <span className={`w-25 ${task.isDone ? "strike" : ""}`}>
            {category?.name || "N/A"}
          </span>
          <span className="w-25 d-flex justify-content-end">
            <input
              type="button"
              value="&#10006;"
              className="btn btn-primary-outline shadow-none "
              onClick={() => dispatch(deleteTask(task.id))}
            />
          </span>
        </div>
      </div>
    </ListGroup.Item>
  );
};

export default TaskTableItem;
