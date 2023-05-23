import { ICategoriesFetchData } from "./types/category";

const API_URL = "https://localhost:7182/graphql";

const getCategoriesQuery = `
query GetCategories{
    categories{
      getCategories{
        id
        name
      }
    }
  }
`;

export const getCategories = async () => {
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
        query: getCategoriesQuery,
      }),
    });
    const data: ICategoriesFetchData = await response.json();
    return data;
  } catch (error) {
    console.error("Error fetching categories:", error);
    throw error;
  }
};
