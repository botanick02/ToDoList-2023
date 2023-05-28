import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { deleteCategory, setCategoryOnDeletion } from "../../../redux/reducers/categories-slice";
import ListGroup from "react-bootstrap/ListGroup";
import { Category } from "../../../redux/types/category";

type CategoriesTableItemProps = {
  category: Category;
};

const CategoriesTableItem = ({ category }: CategoriesTableItemProps) => {
  const taskIdOnDeletion = useAppSelector(
    (state) => state.categories.categoryIdOnDeletion
  );

  const handleTaskDeleteClick = () => {
    if (taskIdOnDeletion) {
      dispatch(deleteCategory({ id: taskIdOnDeletion }));
    }
    dispatch(setCategoryOnDeletion({ id: category.id }));
  };

  const dispatch = useAppDispatch();

  if (category.id === taskIdOnDeletion) {
    return null;
  }

  return (
    <ListGroup.Item className="d-flex w-100">
      <div className="d-flex align-items-center w-100">
        <div className="d-flex w-100 align-items-center text-align-center">
          <span className="w-50">{category.name}</span>
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

export default CategoriesTableItem;
