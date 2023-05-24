import { combineEpics } from "redux-observable";
import { fetchTasksEpic } from "./tasksEpic";
import {
  createCategoryEpic,
  deleteCategoryEpic,
  fetchCategoriesEpic,
} from "./categoriesEpic";

export const rootEpic = combineEpics(
  createCategoryEpic,
  fetchTasksEpic,
  fetchCategoriesEpic,
  deleteCategoryEpic
);
