import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import { Category, DeleteCategoryInput, NewCategory } from "../types/category";

type CategoriesSlice = {
  categoriesList: Category[];
  categoryIdOnDeletion?: number;
};

const initialState: CategoriesSlice = {
  categoriesList: [],
  categoryIdOnDeletion: undefined,
};

const categoriesSlice = createSlice({
  name: "categories",
  initialState,
  reducers: {
    categoryCreated: (state, action: PayloadAction<Category>) => {
      console.log(
        "Category " + action.payload.name + " was successfully added!"
      );
    },
    categoriesFetched: (state, action: PayloadAction<Category[]>) => {
      state.categoriesList = action.payload;
    },
    setCategoryOnDeletion: (state, action: PayloadAction<DeleteCategoryInput>) => {
      state.categoryIdOnDeletion = action.payload.id;
    },
    cancelCategoryDeletion: (state) => {
      state.categoryIdOnDeletion = undefined;
    },
    categoryDeleted: (state, action: PayloadAction<number>) => {
      state.categoriesList = state.categoriesList.filter((c) => c.id !== action.payload);
      if (state.categoryIdOnDeletion === action.payload) {
        state.categoryIdOnDeletion = undefined;
      }
      console.log("Category was successfully deleted!");
    },
  },
});

export const { categoryCreated, categoryDeleted, categoriesFetched,cancelCategoryDeletion, setCategoryOnDeletion } =
  categoriesSlice.actions;
export default categoriesSlice.reducer;

export const fetchCategories = createAction("fetchCategories");
export const createCategory = createAction<NewCategory>("createCategory");
export const deleteCategory =
  createAction<DeleteCategoryInput>("deleteCategory");
