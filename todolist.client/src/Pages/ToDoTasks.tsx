import { useAppDispatch, useAppSelector } from "../app/hooks";
import { addTask } from "../features/tasks/tasks-slice";
import ListGroup from "react-bootstrap/ListGroup";

const ToDoTasks = () => {
  const tasksList = useAppSelector((state) => state.tasks.tasksList);

  return (
    <div className="d-flex justify-content-center align-items-center h-100">
      <div className="col col-xl-6 m-5">
        <div className="shadow p-3 mb-5 bg-white rounded">
          <div className="card-body p-5">
            <form className="d-flex justify-content-between">
              <div className="d-flex flex-column w-25">
                <label htmlFor="title">Title:</label>
                <input type="text" id="title" />
              </div>
              <div className="d-flex flex-column w-25">
                <label htmlFor="dueDate">Due Date:</label>
                <input type="datetime-local" id="dueDate" />
              </div>
              <div className="d-flex flex-column w-25">
                <label htmlFor="categoryId">Category:</label>
                <select id="categoryId"></select>
              </div>
              <button type="submit" className="btn btn-primary">
                Create Task
              </button>
            </form>
            <ListGroup className="mt-4">
              <ListGroup.Item className="d-flex w-100 fw-bold border-bottom border-primary">
                <span className="w-50">Title</span>
                <span className="w-50">Deadline</span>
                <span className="w-25">Category</span>
              </ListGroup.Item>
              {tasksList.map((task) => (
                <ListGroup.Item className="d-flex w-100">
                  <span className="w-50">{task.title}</span>
                  <span className="w-50">{task.dueDate?.toLocaleDateString()}</span>
                  <span className="w-25">{task.categoryId}</span>
                </ListGroup.Item>
              ))}
            </ListGroup>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ToDoTasks;
