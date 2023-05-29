import CategoriesTable from "../components/categories/categoriesTable/CategoriesTable";
import CategoryCreationForm from "../components/categories/forms/CategoryCreationForm";

const Categories = () => {
  return (
    <div className="d-flex justify-content-center align-items-center h-100">
      <div className="col col-xl-6 m-5">
        <div className="shadow p-3 mb-5 bg-white rounded">
          <div className="card-body p-5">
            <CategoryCreationForm />
            <CategoriesTable/>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Categories;
