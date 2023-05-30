import ListGroup from "react-bootstrap/ListGroup";
import TaskTableItem from "./TasksTableItem";
import { Category } from "../../../redux/types/category";
import UndoTaskDeletionNotification from "../UndoTaskDeletionNotification";
import { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { fetchTasks, setPage } from "../../../redux/reducers/tasks-slice";
import PaginationController from "../../common/Pagination";
import { fetchCategories } from "../../../redux/reducers/categories-slice";

type TaskTableProps = {
  categoriesList: Category[];
};

const TasksTable = ({ categoriesList }: TaskTableProps) => {
  const currentPage = useAppSelector(state => state.tasks.currentPage);
  const totalTasksCount = useAppSelector((state) => state.tasks.totalCount);
  const source = useAppSelector((state) => state.storageSources.currentStorage);
  const tasksList = useAppSelector((state) => state.tasks.tasksList);
  const dispatch = useAppDispatch();
  const pageSize = 5;

  useEffect(() => {
    if (source) {
      dispatch(fetchTasks({ pageNumber: currentPage, pageSize: pageSize }));
      dispatch(fetchCategories({pageNumber: 1, pageSize: 1000}));
    }
  }, [currentPage, source, dispatch]);

  return (
    <>
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
        {tasksList.map((task) => (
          <TaskTableItem
            key={task.id}
            task={task}
            category={categoriesList.find((cat) => cat.id === task.categoryId)}
          />
        ))}
      </ListGroup>
      <PaginationController
        currentPage={currentPage}
        onPageChange={(page: number) => dispatch(setPage(page))}
        pageSize={pageSize}
        totalCount={totalTasksCount}
      />
      <UndoTaskDeletionNotification />
    </>
  );
};

export default TasksTable;
