import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import { ITask, NewTaskInputType, NewTaskType } from "../types";
import { DeleteTaskInputType, ToggleTaskInputType } from "../../graphql/tasksApi";

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
    taskCreated: (state, action: PayloadAction<ITask>) => {
      console.log("Task with title " + action.payload.title + " was successfully created!");
    },
    taskDeleted: (state) => {
      console.log("Task was successfully deleted!");
    },
    taskToggled: (state, action: PayloadAction<ITask>) => {
      console.log("Task with title " + action.payload.title + " was successfully toggled!");
    },
    tasksFetched: (state, action: PayloadAction<ITask[]>) => {
      state.tasksList = action.payload;
    },
  },
});

export const { tasksFetched, taskCreated, taskDeleted, taskToggled } = tasksSlice.actions;
export default tasksSlice.reducer;

export const fetchTasks = createAction("fetchTasks");
export const createTask = createAction<NewTaskType>("createTask");
export const toggleTask = createAction<ToggleTaskInputType>("toggleTask");
export const deleteTask = createAction<DeleteTaskInputType>("deleteTask");
