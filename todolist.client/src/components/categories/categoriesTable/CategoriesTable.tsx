import ListGroup from "react-bootstrap/ListGroup";
import CategoriesTableItem from "./CategoriesTableItem";
import UndoCategoryDeletionNotification from "../UndoCategoryDeletionNotification";
import { useEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../../redux/hooks";
import { fetchCategories } from "../../../redux/reducers/categories-slice";


const CategoriesTable = () => {
  const source = useAppSelector((state) => state.storageSources.currentStorage);
  const dispatch = useAppDispatch();
  const categoriesList = useAppSelector(state => state.categories.categoriesList);
  useEffect(() => {
    if(source){
    dispatch(fetchCategories())
    }
  }, [source, dispatch])

  return (
    <>
    <ListGroup className="mt-4">
      <ListGroup.Item className="d-flex w-100">
        <div className="d-flex align-items-center w-100">
          <div className="d-flex w-100">
            <span className="w-50">Name</span>
          </div>
        </div>
      </ListGroup.Item>
      {categoriesList
        .filter((cat) => cat.id !== 1)
        .map((category) => (
          <CategoriesTableItem key={category.id} category={category} />
        ))}
    </ListGroup>
    <UndoCategoryDeletionNotification/>
    </>
  );
};

export default CategoriesTable;
