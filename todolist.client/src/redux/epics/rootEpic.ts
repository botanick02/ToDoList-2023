import { combineEpics } from "redux-observable";
import { createTaskEpic, deleteTaskEpic, fetchTasksEpic, toggleTaskEpic } from "./tasksEpic";
import {
  createCategoryEpic,
  deleteCategoryEpic,
  fetchCategoriesEpic,
} from "./categoriesEpic";

export const rootEpic = combineEpics(
  createCategoryEpic,
  fetchTasksEpic,
  fetchCategoriesEpic,
  deleteCategoryEpic,
  createTaskEpic,
  deleteTaskEpic,
  toggleTaskEpic
);
