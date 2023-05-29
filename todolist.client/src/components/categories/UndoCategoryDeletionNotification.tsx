import { useAppDispatch, useAppSelector } from "../../redux/hooks";
import {
  cancelCategoryDeletion,
  deleteCategory,
} from "../../redux/reducers/categories-slice";
import UndoDeletionNotification from "../common/UndoDeletionNotification";

const UndoCategoryDeletionNotification = () => {
  const categoryIdOnDeletion = useAppSelector(
    (state) => state.categories.categoryIdOnDeletion
  );
  const dispatch = useAppDispatch();

  if (!categoryIdOnDeletion) {
    return null;
  }

  return (
    <UndoDeletionNotification
      message="category deletedion"
      undoDeletion={() => dispatch(cancelCategoryDeletion())}
      proceedDeletion={() =>
        dispatch(deleteCategory({ id: categoryIdOnDeletion }))
      }
    />
  );
};

export default UndoCategoryDeletionNotification;
