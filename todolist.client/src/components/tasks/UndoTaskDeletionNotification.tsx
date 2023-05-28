import { useAppDispatch, useAppSelector } from "../../redux/hooks";
import {
  cancelTaskDeletion,
  deleteTask,
} from "../../redux/reducers/tasks-slice";
import UndoDeletionNotification from "../common/UndoDeletionNotification";

const UndoTaskDeletionNotification = () => {
  const taskIdOnDeletion = useAppSelector(
    (state) => state.tasks.taskIdOnDeletion
  );
  const dispatch = useAppDispatch();

  if (!taskIdOnDeletion) {
    return null;
  }

  return (
    <UndoDeletionNotification
      message="task deletedion"
      undoDeletion={() => dispatch(cancelTaskDeletion())}
      proceedDeletion={() => dispatch(deleteTask({ id: taskIdOnDeletion }))}
    />
  );
};

export default UndoTaskDeletionNotification;
