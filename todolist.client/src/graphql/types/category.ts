import { ICategory } from "../../redux/types";
import { GraphQlResponse } from "./graphqlReponse";

export type FetchCategoriesResponse = GraphQlResponse<{
  categories: {
    allCategories: ICategory[];
  };
}>;
