import { graphQLFetch } from "./api";
import { AddCategoryResponse, FetchCategoriesResponse } from "./types/category";

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

export const getCategoriesApi = async () => {
  try {
    return await graphQLFetch<FetchCategoriesResponse>(getCategoriesQuery);
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};

const createCategoryMutation = `
  mutation CreateCategory($category: NewCategoryInputType!){
    categories{
      createCategory(newCategoryInputType: $category){
        id
        name
      }
    }
  }
`;

export type NewCategoryInputType = {
  name: string;
};

type createCategoryMutationVariables = {
  category: NewCategoryInputType;
};

export const createCategoryApi = async (newCategory: NewCategoryInputType) => {
  try {
    const inputVariables: createCategoryMutationVariables = {
      category: newCategory,
    };
    return await graphQLFetch<AddCategoryResponse>(
      createCategoryMutation,
      inputVariables
    );
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};

const deleteCategoryMutation = `
  mutation DeleteCategory($id: Int!){
    categories{
      deleteCategory(categoryId: $id)
    }
  }
`;

export type DeleteCategoryInputType = {
  id: number;
};

type deleteCategoryMutationVariables = DeleteCategoryInputType;

export const deleteCategoryApi = async (input: DeleteCategoryInputType) => {
  try {
    const inputVariables: deleteCategoryMutationVariables = {
      id: input.id,
    };
    return await graphQLFetch(deleteCategoryMutation, inputVariables);
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};
