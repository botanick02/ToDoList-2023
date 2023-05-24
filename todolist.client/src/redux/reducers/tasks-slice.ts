import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import { ITask, ITaskInputType } from "../types";

interface TasksSlice {
  tasksList: ITask[];
}

const initialState: TasksSlice = {
  tasksList: [],
};

const tasksSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    tasksFetched: (state, action: PayloadAction<ITask[]>) => {
      state.tasksList = action.payload;
    },
  },
});

export const { tasksFetched } = tasksSlice.actions;
export default tasksSlice.reducer;


export const fetchTasks = createAction("fetchTasks");
export const toggleTask = createAction("toggleTask");
export const deleteTask = createAction("deleteTask");

