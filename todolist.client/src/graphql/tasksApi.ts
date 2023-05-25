import { NewTaskInputType } from "../redux/types";
import { graphQLFetch } from "./api";
import { AddTaskResponse, FetchTasksResponse, ToggleTaskResponse } from "./types/task";

const getTasksQuery = `
query GetAllTasks{
  tasks{
    allTasks{
      id
      title
      categoryId
      dueDate
      isDone
    }
  }
}
`;

export const fetchTasksApi = async () => {
  try {
    return await graphQLFetch<FetchTasksResponse>(getTasksQuery);
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
  task: NewTaskInputType;
};

export const createTaskApi = async (newTask: NewTaskInputType) => {
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
  mutation DeleteTask($taskId: Int!){
    tasks{
      deleteTask(taskId: $taskId)
    }
  }
`;

export type DeleteTaskInputType = {
  taskId: number;
};

type deleteTaskMutationVariables = DeleteTaskInputType;

export const deleteTaskApi = async (input: DeleteTaskInputType) => {
  try {
    const inputVariables: deleteTaskMutationVariables = {
      taskId: input.taskId,
    };
    return await graphQLFetch(deleteTaskMutation, inputVariables);
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};

const toggleTaskMutation = `
  mutation ToggleTask($taskId: Int!){
    tasks{
      toggleIsDone(taskId: $taskId){
        title
        dueDate
        id
        isDone
      }
    }
  }
`;

export type ToggleTaskInputType = {
  taskId: number;
};

type toggleTaskMutationVariables = ToggleTaskInputType;

export const toggleTaskApi = async (input: ToggleTaskInputType) => {
  try {
    const inputVariables: toggleTaskMutationVariables = {
      taskId: input.taskId,
    };
    return await graphQLFetch<ToggleTaskResponse>(toggleTaskMutation, inputVariables);
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};
