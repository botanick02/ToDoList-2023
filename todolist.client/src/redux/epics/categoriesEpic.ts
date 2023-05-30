import { Epic, ofType } from "redux-observable";
import { from, map, mergeMap } from "rxjs";
import { Action } from "@reduxjs/toolkit";
import {
  createCategoryApi,
  deleteCategoryApi,
  fetchCategoriesApi,
} from "../../graphql/categoriesApi";
import {
  categoryCreated,
  categoriesFetched,
  createCategory,
  fetchCategories,
  categoryDeleted,
  deleteCategory,
} from "../reducers/categories-slice";
import { fetchTasksPaged } from "../../utils/fetchHelper";

export const fetchCategoriesEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof fetchCategories>, any, any>("fetchCategories"),
    mergeMap((action) =>
      from(fetchCategoriesApi(action.payload.pageNumber, action.payload.pageSize)).pipe(
        map((response) => categoriesFetched(response.categories.getCategories))
      )
    )
  );

export const createCategoryEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof createCategory>, any, any>("createCategory"),
    mergeMap((action) =>
      from(createCategoryApi(action.payload)).pipe(
        mergeMap((response) => [
          fetchCategories({pageNumber: 1, pageSize: 5}),
          categoryCreated(response.categories.createCategory)]
        )
      )
    )
  );

export const deleteCategoryEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof deleteCategory>, any, any>("deleteCategory"),
    mergeMap((action) =>
      from(deleteCategoryApi(action.payload)).pipe(
        map((response) => {
          fetchTasksPaged();
          return categoryDeleted(response.categories.deleteCategory)})
      )
    )
  );
