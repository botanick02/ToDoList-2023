import { Task } from "../../redux/types/task";
import { GraphQlResponse } from "./graphqlReponse";

export type FetchTasksResponse = GraphQlResponse<{
  tasks: {
    getTasks: {
      tasks: Task[];
      totalCount: number;
    }
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

export type DeleteTaskResponse = GraphQlResponse<{
  tasks: {
    deleteTask: number;
  };
}>;
