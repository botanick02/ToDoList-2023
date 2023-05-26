import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import { Category, DeleteCategoryInput, NewCategory } from "../types/category";

interface CategoriesSlice {
  categoriesList: Category[];
}

const initialState: CategoriesSlice = {
  categoriesList: [],
};

const categoriesSlice = createSlice({
  name: "categories",
  initialState,
  reducers: {
    categoryCreated: (state, action: PayloadAction<Category>) => {
      console.log(
        "Category" + action.payload.name + " was successfully added!"
      );
    },
    categoriesFetched: (state, action: PayloadAction<Category[]>) => {
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
  createAction<NewCategory>("createCategory");
export const deleteCategory =
  createAction<DeleteCategoryInput>("deleteCategory");
