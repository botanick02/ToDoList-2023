import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import { ICategory } from "../types";
import {
  DeleteCategoryInputType,
  NewCategoryInputType,
} from "../../graphql/categoriesApi";

interface CategoriesSlice {
  categoriesList: ICategory[];
}

const initialState: CategoriesSlice = {
  categoriesList: [],
};

const categoriesSlice = createSlice({
  name: "categories",
  initialState,
  reducers: {
    categoryCreated: (state, action: PayloadAction<ICategory>) => {
      console.log(
        "Category" + action.payload.name + " was successfully added!"
      );
    },
    categoriesFetched: (state, action: PayloadAction<ICategory[]>) => {
      state.categoriesList = action.payload;
    },
    categoryDeleted: () => {
      console.log("Category was successfully deleted!");
    },
  },
});

export const { categoryCreated, categoryDeleted, categoriesFetched } =
  categoriesSlice.actions;
export default categoriesSlice.reducer;

export const fetchCategories = createAction("fetchCategories");
export const createCategory =
  createAction<NewCategoryInputType>("createCategory");
export const deleteCategory =
  createAction<DeleteCategoryInputType>("deleteCategory");
