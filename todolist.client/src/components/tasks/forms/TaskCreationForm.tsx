import { useAppDispatch } from "../../../redux/hooks";
import { SubmitHandler, useForm } from "react-hook-form";
import { ICategory, NewTaskInputType, NewTaskType } from "../../../redux/types";
import { createTask } from "../../../redux/reducers/tasks-slice";

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
  } = useForm<NewTaskInputType>({
    defaultValues: {
      title: '',
      dueDate: '',
      categoryId: '1'
    }
  });

  const onSubmit: SubmitHandler<NewTaskInputType> = (data) => {
    const newTask: NewTaskType = {
      title: data.title,
      dueDate: data.dueDate === "" ? undefined : new Date(data.dueDate),
      categoryId: +data.categoryId ?? 1,
    }
    dispatch(createTask(newTask))
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
