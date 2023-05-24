import { useAppDispatch } from "../../../redux/hooks";
import { deleteCategory } from "../../../redux/reducers/categories-slice";
import { ICategory } from "../../../redux/types";
import ListGroup from "react-bootstrap/ListGroup";

interface ICategoriesTableItemProps {
  category: ICategory;
}

const CategoriesTableItem = ({ category }: ICategoriesTableItemProps) => {
  const dispatch = useAppDispatch();

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
              onClick={() => dispatch(deleteCategory({ id: category.id }))}
            />
          </span>
        </div>
      </div>
    </ListGroup.Item>
  );
};

export default CategoriesTableItem;
