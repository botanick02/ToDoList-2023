import { NewCategory, DeleteCategoryInput } from "../redux/types/category";
import { graphQLFetch } from "./api";
import {
  AddCategoryResponse,
  DeleteCategoryResponse,
  FetchCategoriesResponse,
} from "./types/category";

const getCategoriesQuery = `
query GetCategories($pageNumber: Int!, $pageSize: Int!){
    categories{
      getCategories(pageNumber: $pageNumber, pageSize: $pageSize){
        categories{
          id
          name
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

export const fetchCategoriesApi = async (
  pageNumber: number,
  pageSize: number
) => {
  try {
    const inputVariables: fetchTasksMutationVariables = {
      pageNumber,
      pageSize,
    };
    return await graphQLFetch<FetchCategoriesResponse>(
      getCategoriesQuery,
      inputVariables
    );
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
    return await graphQLFetch<DeleteCategoryResponse>(
      deleteCategoryMutation,
      inputVariables
    );
  } catch (error) {
    console.error("Error in graphql request processing:", error);
    throw error;
  }
};
