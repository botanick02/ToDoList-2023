import { Epic, ofType } from "redux-observable";
import {from, map, mergeMap} from "rxjs";
import { Action } from "@reduxjs/toolkit";
import { getCategories } from "../../graphql/categoriesApi";
import { categoriesFetched } from "../reducers/categories-slice";


export const fetchCategoriesEpic: Epic<Action<any>, Action<any>, void, any> = (action$) => {
    return action$.pipe(
        ofType("fetchCategories"),
        mergeMap(action => from(getCategories()).pipe(map(response => categoriesFetched(response.categories.allCategories)))
        )
    )
}