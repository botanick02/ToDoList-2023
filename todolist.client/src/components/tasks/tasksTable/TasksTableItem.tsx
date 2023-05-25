import { useAppDispatch } from "../../../redux/hooks";
import { ICategory, ITask } from "../../../redux/types";
import ListGroup from "react-bootstrap/ListGroup";
import { stringToFormattedDateString } from "../../../utils/dateUtils";

interface ITaskTableItemProps {
  task: ITask;
  category?: ICategory;
}

const TasksTableItem = ({ task, category }: ITaskTableItemProps) => {
  const dispatch = useAppDispatch();
  return (
    <ListGroup.Item className="d-flex w-100">
      <div className="d-flex align-items-center w-100">
        <div className="d-flex w-100 align-items-center text-align-center">
          <span>
            <input
              type="checkbox"
              // onClick={() => dispatch(toggleTask(task.id))}
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
              // onClick={() => dispatch(deleteTask(task.id))}
            />
          </span>
        </div>
      </div>
    </ListGroup.Item>
  );
};

export default TasksTableItem;
