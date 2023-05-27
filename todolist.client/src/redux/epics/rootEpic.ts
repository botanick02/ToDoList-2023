import { combineEpics } from "redux-observable";
import {
  createTaskEpic,
  deleteTaskEpic,
  fetchTasksEpic,
  toggleTaskEpic,
} from "./tasksEpic";
import {
  createCategoryEpic,
  deleteCategoryEpic,
  fetchCategoriesEpic,
} from "./categoriesEpic";
import { fetchStorageSourcesEpic } from "./storageSourcesEpic";

export const rootEpic = combineEpics(
  createCategoryEpic,
  fetchTasksEpic,
  fetchCategoriesEpic,
  deleteCategoryEpic,
  createTaskEpic,
  deleteTaskEpic,
  toggleTaskEpic,
  fetchStorageSourcesEpic
);
