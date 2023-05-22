import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ICategory, ICategoryInputType } from "./types";

interface CategoriesSlice {
  categoriesList: ICategory[];
}

const initialState: CategoriesSlice = {
  categoriesList: [
    {
      id: 0,
      name: "Uncategorized",
    },
    {
      id: 1,
      name: "Work",
    },
    {
      id: 2,
      name: "Uni",
    },
  ],
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
    deleteCategory: (state, action: PayloadAction<number>) => {
      const categoryId = action.payload;
      state.categoriesList = state.categoriesList.filter(
        (category) => category.id !== categoryId
      );
    },
  },
});

export const { addCategory, deleteCategory } = categoriesSlice.actions;
export default categoriesSlice.reducer;
