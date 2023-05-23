import { useAppDispatch } from "../../../redux/hooks";
import { addTask } from "../../../redux/slices/tasks-slice";
import { SubmitHandler, useForm } from "react-hook-form";
import { ICategory, ITaskInputType } from "../../../redux/types";

interface ITaskCreationFormProps {
  categoriesList: ICategory[];
}

const TaskCreationForm = ({ categoriesList }: ITaskCreationFormProps) => {
  const dispatch = useAppDispatch();
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<ITaskInputType>();

  const onSubmit: SubmitHandler<ITaskInputType> = (data) => {
    dispatch(addTask(data));
    reset();
  };

  return (
    <form
      className="d-flex justify-content-between"
      onSubmit={handleSubmit(onSubmit)}
    >
      <div className="d-flex flex-column w-25">
        <label htmlFor="title">Title:</label>
        <input {...register("title", { required: true, maxLength: 20 })} />
        {errors.title?.type === "required" && (
          <p className="error">Title is required.</p>
        )}
        {errors.title?.type === "maxLength" && (
          <p className="error">Title should be within 20 characters.</p>
        )}
      </div>
      <div className="d-flex flex-column w-25">
        <label htmlFor="dueDate">Due Date:</label>
        <input
          type="datetime-local"
          {...register("dueDate", { required: false })}
        />
      </div>
      <div className="d-flex flex-column w-25">
        <label htmlFor="categoryId">Category:</label>
        <select {...register("categoryId", { required: false })}>
          {categoriesList.map((cat) => (
            <option key={cat.id} value={cat.id}>
              {cat.name}
            </option>
          ))}
        </select>
      </div>
      <button type="submit" className="btn btn-primary">
        Create Task
      </button>
    </form>
  );
};

export default TaskCreationForm;
