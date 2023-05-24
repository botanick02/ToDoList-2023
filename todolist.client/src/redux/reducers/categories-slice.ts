import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import { ICategory, ICategoryInputType } from "../types";

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
    addCategory: (state, action: PayloadAction<ICategoryInputType>) => {
      const newCategory: ICategory = {
        id: Date.now(),
        name: action.payload.name,
      };
      state.categoriesList.push(newCategory);
    },
    categoriesFetched: (state, action: PayloadAction<ICategory[]>) => {
      state.categoriesList = action.payload;
    },
    deleteCategory: (state, action: PayloadAction<number>) => {
      const categoryId = action.payload;
      state.categoriesList = state.categoriesList.filter(
        (category) => category.id !== categoryId
      );
    },
  },
});

export const { addCategory, deleteCategory, categoriesFetched } = categoriesSlice.actions;
export default categoriesSlice.reducer;

export const fetchCategories = createAction("fetchCategories");
