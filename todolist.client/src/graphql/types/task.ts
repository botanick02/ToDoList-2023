import { ITask } from "../../redux/types";
import { GraphQlResponse } from "./graphqlReponse";

export type FetchTasksResponse = GraphQlResponse<{
  categories: {
    allCategories: ITask[];
  };
}>;
