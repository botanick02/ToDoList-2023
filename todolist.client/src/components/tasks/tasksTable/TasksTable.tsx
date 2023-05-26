import ListGroup from "react-bootstrap/ListGroup";
import TaskTableItem from "./TasksTableItem";
import { Category } from "../../../redux/types/category";
import { Task } from "../../../redux/types/task";

type TaskTableProps = {
  tasksList: Task[];
  categoriesList: Category[];
};

const TasksTable = ({ tasksList, categoriesList }: TaskTableProps) => {
  var tasksListSorted = [...tasksList].sort((task1, task2) => {
    if (task1.isDone) {
      return 1;
    }
    if (task2.isDone) {
      return -1;
    }
    if (task1.dueDate === "") {
      return 1;
    }
    if (task2.dueDate === "") {
      return -1;
    }
    return Date.parse(task1.dueDate) - Date.parse(task2.dueDate);
  });
  return (
    <ListGroup className="mt-4">
      <ListGroup.Item className="d-flex w-100">
        <div className="d-flex align-items-center w-100">
          <div className="d-flex w-100">
            <span className="w-50 text-center">Title</span>
            <span className="w-50 px-3 text-center">Daeadline</span>
            <span className="w-25 text-center">Category</span>
            <span className="w-25"></span>
          </div>
        </div>
      </ListGroup.Item>
      {tasksListSorted.map((task) => (
        <TaskTableItem
          key={task.id}
          task={task}
          category={categoriesList.find((cat) => cat.id === task.categoryId)}
        />
      ))}
    </ListGroup>
  );
};

export default TasksTable;
