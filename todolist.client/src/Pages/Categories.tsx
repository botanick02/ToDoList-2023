import { useAppSelector } from "../app/hooks";
import CategoriesTable from "../components/categories/categoriesTable/CategoriesTable";
import CategoryCreationForm from "../components/categories/forms/CategoryCreationForm";

const Categories = () => {
  const categoriesList = useAppSelector(state => state.categories.categoriesList);

  return(
    <div className="d-flex justify-content-center align-items-center h-100">
      <div className="col col-xl-6 m-5">
        <div className="shadow p-3 mb-5 bg-white rounded">
          <div className="card-body p-5">
            <CategoryCreationForm/>
            <CategoriesTable categoriesList={categoriesList} />
          </div>
        </div>
      </div>
    </div>
  )
};

export default Categories;
