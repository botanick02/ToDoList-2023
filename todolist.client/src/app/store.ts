import { configureStore } from "@reduxjs/toolkit";
import tasksReducer from "../features/tasks/tasks-slice";
import categoriesReducer from "../features/tasks/categories-slice";

export const store = configureStore({
  reducer: {
    tasks: tasksReducer,
    categories: categoriesReducer,
  },
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
