import { NewCategory, DeleteCategoryInput } from "../redux/types/category";
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

type createCategoryMutationVariables = {
  category: NewCategory;
};

export const createCategoryApi = async (newCategory: NewCategory) => {
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

type deleteCategoryMutationVariables = DeleteCategoryInput;

export const deleteCategoryApi = async (input: DeleteCategoryInput) => {
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
