import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ICategory } from "./types";

interface CategoriesSlice {
  categoriesList: ICategory[];
}

const initialState: CategoriesSlice = {
  categoriesList: [
    {
      id: 0,
      name: "Uncategorized"
    },
    {
      id: 1,
      name: "Work"
    },
    {
      id: 2,
      name: "Uni"
    },
  ],
};

const categoriesSlice = createSlice({
  name: "categories",
  initialState,
  reducers: {
    addCategory: (state, action: PayloadAction<ICategory>) => {
      state.categoriesList.push(action.payload);
    },
  },
});

export const { addCategory } = categoriesSlice.actions;
export default categoriesSlice.reducer;
