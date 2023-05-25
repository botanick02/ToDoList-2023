import { ITask } from "../../redux/types";
import { GraphQlResponse } from "./graphqlReponse";

export type FetchTasksResponse = GraphQlResponse<{
  categories: {
    allCategories: ITask[];
  };
}>;

export type AddTaskResponse = GraphQlResponse<{
  tasks: {
    createTask: ITask;
  };
}>;

export type ToggleTaskResponse = GraphQlResponse<{
  tasks: {
    toggleIsDone: ITask;
  };
}>;