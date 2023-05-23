import { ICategory } from "../../../redux/types";
import ListGroup from "react-bootstrap/ListGroup";
import CategoriesTableItem from "./CategoriesTableItem";

interface ITaskTableProps {
  categoriesList: ICategory[];
}

const CategoriesTable = ({ categoriesList }: ITaskTableProps) => {
  return (
    <ListGroup className="mt-4">
      <ListGroup.Item className="d-flex w-100">
        <div className="d-flex align-items-center w-100">
          <div className="d-flex w-100">
            <span className="w-50">Name</span>
          </div>
        </div>
      </ListGroup.Item>
      {categoriesList.filter(cat => cat.id !== 1).map((category) => (
        <CategoriesTableItem key={category.id} category={category}/>
      ))}
    </ListGroup>
  );
};

export default CategoriesTable;
