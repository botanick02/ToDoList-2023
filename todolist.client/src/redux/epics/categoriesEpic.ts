import { Epic, ofType } from "redux-observable";
import { from, map, mergeMap } from "rxjs";
import { Action } from "@reduxjs/toolkit";
import {
  createCategoryApi,
  deleteCategoryApi,
  getCategoriesApi,
} from "../../graphql/categoriesApi";
import {
  categoryAdded,
  categoriesFetched,
  createCategory,
  fetchCategories,
  categoryDeleted,
  deleteCategory,
} from "../reducers/categories-slice";

export const fetchCategoriesEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof fetchCategories>, any, any>("fetchCategories"),
    mergeMap((action) =>
      from(getCategoriesApi()).pipe(
        map((response) => categoriesFetched(response.categories.allCategories))
      )
    )
  );

export const createCategoryEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof createCategory>, any, any>("createCategory"),
    mergeMap((action) =>
      from(createCategoryApi(action.payload)).pipe(
        mergeMap((response) => [
          categoryAdded(response.categories.createCategory),
          fetchCategories(),
        ])
      )
    )
  );

export const deleteCategoryEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof deleteCategory>, any, any>("deleteCategory"),
    mergeMap((action) =>
      from(deleteCategoryApi(action.payload)).pipe(
        mergeMap(() => [categoryDeleted(), fetchCategories()])
      )
    )
  );
