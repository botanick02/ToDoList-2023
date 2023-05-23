import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";
import tasksReducer from "./slices/tasks-slice";
import categoriesReducer from "./slices/categories-slice";
import { createEpicMiddleware } from "redux-observable";
import { rootEpic } from "./epics/rootEpic";

const epicMiddleware = createEpicMiddleware();
const middleware = [...getDefaultMiddleware(), epicMiddleware];

export const store = configureStore({
  reducer: {
    tasks: tasksReducer,
    categories: categoriesReducer,
  },
  middleware: middleware,
});

epicMiddleware.run(rootEpic);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
