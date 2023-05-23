import { ITasksFetchData } from "./types/task";

const API_URL = "https://localhost:7182/graphql";

const getTasksQuery = `
query GetAllTasks{
  tasks{
    getTasks{
      id
      title
      categoryId
      dueDate
      isDone
    }
  }
}
`;

export const getTasks = async () => {
  try {
    const response = await fetch(API_URL, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
        Source: "MsSQL",
      },
      body: JSON.stringify({
        query: getTasksQuery,
      }),
    });

    const data: ITasksFetchData = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching tasks:", error);
    throw error;
  }
};
