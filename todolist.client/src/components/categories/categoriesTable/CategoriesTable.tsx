import ListGroup from "react-bootstrap/ListGroup";
import CategoriesTableItem from "./CategoriesTableItem";
import { Category } from "../../../redux/types/category";

type CategoriesTableProps = {
  categoriesList: Category[];
}

const CategoriesTable = ({ categoriesList }: CategoriesTableProps) => {
  return (
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
  );
};

export default CategoriesTable;
