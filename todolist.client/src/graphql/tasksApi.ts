import {
  NewTask,
  DeleteTaskInputType,
  ToggleTaskInputType,
} from "../redux/types/task";
import { graphQLFetch } from "./api";
import {
  AddTaskResponse,
  DeleteTaskResponse,
  FetchTasksResponse,
  ToggleTaskResponse,
} from "./types/task";

const getTasksQuery = `
query GetAllTasks($pageNumber: Int!, $pageSize: Int!){
  tasks{
    getTasks(pageNumber: $pageNumber, pageSize: $pageSize){
      tasks{
        id
        title
        categoryId
        dueDate
        isDone
      }
      totalCount
    }
  }
}
`;

type fetchTasksMutationVariables = {
  pageNumber: number;
  pageSize: number;
};

export const fetchTasksApi = async (pageNumber: number, pageSize: number) => {
  try {
    const inputVariables: fetchTasksMutationVariables = {
      pageNumber,
      pageSize,
    };
    return await graphQLFetch<FetchTasksResponse>(
      getTasksQuery,
      inputVariables
    );
  } catch (error) {
    console.error("Error fetching categories:", error);
    throw error;
  }
};

const createTaskMutation = `
  mutation CreateTask($task: NewTaskInputType!){
    tasks{
      createTask(newTaskInputType: $task){
        title
        id
        dueDate
        isDone
      }
    }
  }
`;

type createTaskMutationVariables = {
  task: NewTask;
};

export const createTaskApi = async (newTask: NewTask) => {
  try {
    const inputVariables: createTaskMutationVariables = {
      task: newTask,
    };
    return await graphQLFetch<AddTaskResponse>(
      createTaskMutation,
      inputVariables
    );
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};

const deleteTaskMutation = `
  mutation DeleteTask($id: Int!){
    tasks{
      deleteTask(id: $id)
    }
  }
`;

type deleteTaskMutationVariables = DeleteTaskInputType;

export const deleteTaskApi = async (input: DeleteTaskInputType) => {
  try {
    const inputVariables: deleteTaskMutationVariables = {
      id: input.id,
    };
    return await graphQLFetch<DeleteTaskResponse>(
      deleteTaskMutation,
      inputVariables
    );
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};

const toggleTaskMutation = `
  mutation ToggleTask($id: Int!){
    tasks{
      toggleIsDone(id: $id){
        title
        dueDate
        id
        isDone
      }
    }
  }
`;

type toggleTaskMutationVariables = ToggleTaskInputType;

export const toggleTaskApi = async (input: ToggleTaskInputType) => {
  try {
    const inputVariables: toggleTaskMutationVariables = {
      id: input.id,
    };
    return await graphQLFetch<ToggleTaskResponse>(
      toggleTaskMutation,
      inputVariables
    );
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};
