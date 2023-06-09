import { Category } from "../../redux/types/category";
import { GraphQlResponse } from "./graphqlReponse";

export type FetchCategoriesResponse = GraphQlResponse<{
  categories: {
    categories: Category[];
    totalCount: number;
  };
}>;

export type AddCategoryResponse = GraphQlResponse<{
  categories: {
    createCategory: Category;
  };
}>;

export type DeleteCategoryResponse = GraphQlResponse<{
  categories: {
    deleteCategory: Category;
  };
}>;
