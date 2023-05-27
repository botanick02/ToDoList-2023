import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import {
  Task,
  NewTask,
  ToggleTaskInputType,
  DeleteTaskInputType,
} from "../types/task";

type TasksSlice = {
  tasksList: Task[];
};

const initialState: TasksSlice = {
  tasksList: [],
};

const tasksSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    taskCreated: (state, action: PayloadAction<Task>) => {
      console.log(
        "Task with title " + action.payload.title + " was successfully created!"
      );
    },
    taskDeleted: (state) => {
      console.log("Task was successfully deleted!");
    },
    taskToggled: (state, action: PayloadAction<Task>) => {
      console.log(
        "Task with title " + action.payload.title + " was successfully toggled!"
      );
    },
    tasksFetched: (state, action: PayloadAction<Task[]>) => {
      state.tasksList = action.payload;
    },
  },
});

export const { tasksFetched, taskCreated, taskDeleted, taskToggled } =
  tasksSlice.actions;
export default tasksSlice.reducer;

export const fetchTasks = createAction("fetchTasks");
export const createTask = createAction<NewTask>("createTask");
export const toggleTask = createAction<ToggleTaskInputType>("toggleTask");
export const deleteTask = createAction<DeleteTaskInputType>("deleteTask");
