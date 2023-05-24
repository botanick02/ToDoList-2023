import { graphQLFetch } from "./api";
import { FetchCategoriesResponse } from "./types/category";
import { GraphQlData, GraphQlResponse } from "./types/graphqlReponse";

const getCategoriesQuery = `
query GetCategories{
    categories{
      allCategories{
        id
        name
      }
    }
  }
`;

export const getCategories = async () => {
  try {
    return await graphQLFetch<FetchCategoriesResponse>(getCategoriesQuery);
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};
