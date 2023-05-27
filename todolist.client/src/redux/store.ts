import { configureStore } from "@reduxjs/toolkit";
import tasksReducer from "./reducers/tasks-slice";
import categoriesReducer from "./reducers/categories-slice";
import storageSourcesReducer from "./reducers/storageSource-slice";
import { createEpicMiddleware } from "redux-observable";
import { rootEpic } from "./epics/rootEpic";

const epicMiddleware = createEpicMiddleware();

export const store = configureStore({
  reducer: {
    tasks: tasksReducer,
    categories: categoriesReducer,
    storageSources: storageSourcesReducer,
  },
  middleware: [epicMiddleware],
});

epicMiddleware.run(rootEpic);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
