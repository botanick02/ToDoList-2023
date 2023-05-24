import { graphQLFetch } from "./api";
import { FetchTasksResponse } from "./types/task";

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
