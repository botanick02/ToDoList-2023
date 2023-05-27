import { Task } from "../../redux/types/task";
import { GraphQlResponse } from "./graphqlReponse";

export type FetchTasksResponse = GraphQlResponse<{
  categories: {
    allCategories: Task[];
  };
}>;

export type AddTaskResponse = GraphQlResponse<{
  tasks: {
    createTask: Task;
  };
}>;

export type ToggleTaskResponse = GraphQlResponse<{
  tasks: {
    toggleIsDone: Task;
  };
}>;
