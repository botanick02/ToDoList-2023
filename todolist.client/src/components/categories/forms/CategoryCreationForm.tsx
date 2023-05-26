import { useAppDispatch } from "../../../redux/hooks";
import { createCategory } from "../../../redux/reducers/categories-slice";
import { SubmitHandler, useForm } from "react-hook-form";
import { NewCategory } from "../../../redux/types/category";

const CategoryCreationForm = () => {
  const dispatch = useAppDispatch();
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<NewCategory>();

  const onSubmit: SubmitHandler<NewCategory> = (data) => {
    dispatch(createCategory(data));
    reset();
  };

  return (
    <form
      className="d-flex justify-content-between"
      onSubmit={handleSubmit(onSubmit)}
    >
      <div className="d-flex flex-column w-25">
        <label htmlFor="title">Title:</label>
        <input {...register("name", { required: true, maxLength: 20 })} />
        {errors.name?.type === "required" && (
          <p className="error">Title is required.</p>
        )}
        {errors.name?.type === "maxLength" && (
          <p className="error">Title should be within 20 characters.</p>
        )}
      </div>
      <button type="submit" className="btn btn-primary">
        Create Category
      </button>
    </form>
  );
};

export default CategoryCreationForm;
