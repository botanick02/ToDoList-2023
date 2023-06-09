import { useAppSelector } from "../redux/hooks";
import TaskCreationForm from "../components/tasks/forms/TaskCreationForm";
import TaskTable from "../components/tasks/tasksTable/TasksTable";

const ToDoTasks = () => {
  const categoriesList = useAppSelector(state => state.categories.categoriesList);
  
  return (
    <div className="d-flex justify-content-center align-items-center h-100">
      <div className="col col-xl-6 m-5">
        <div className="shadow p-3 mb-5 bg-white rounded">
          <div className="card-body p-5">
            <TaskCreationForm categoriesList={categoriesList} />
            <TaskTable categoriesList={categoriesList} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ToDoTasks;
