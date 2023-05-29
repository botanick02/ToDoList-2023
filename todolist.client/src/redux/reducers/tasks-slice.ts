import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";
import {
  Task,
  NewTask,
  ToggleTaskInputType,
  DeleteTaskInputType,
  FetchTasksInputType,
} from "../types/task";

type TasksSlice = {
  tasksList: Task[];
  taskIdOnDeletion?: number;
  totalCount: number;
};

const initialState: TasksSlice = {
  tasksList: [],
  taskIdOnDeletion: undefined,
  totalCount: 0,
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
    setTaskOnDeletion: (state, action: PayloadAction<DeleteTaskInputType>) => {
      state.taskIdOnDeletion = action.payload.id;
    },
    cancelTaskDeletion: (state) => {
      state.taskIdOnDeletion = undefined;
    },
    taskDeleted: (state, action: PayloadAction<number>) => {
      state.tasksList = state.tasksList.filter((t) => t.id !== action.payload);
      if (state.taskIdOnDeletion === action.payload) {
        state.taskIdOnDeletion = undefined;
      }
      console.log("Task was successfully deleted!");
    },
    taskToggled: (state, action: PayloadAction<Task>) => {
      console.log(
        "Task with title " + action.payload.title + " was successfully toggled!"
      );
    },
    tasksFetched: (
      state,
      action: PayloadAction<{
        tasks: Task[];
        totalCount: number;
      }>
    ) => {
      state.tasksList = action.payload.tasks;
      state.totalCount = action.payload.totalCount;
    },
  },
});

export const {
  tasksFetched,
  taskCreated,
  taskDeleted,
  taskToggled,
  cancelTaskDeletion,
  setTaskOnDeletion,
} = tasksSlice.actions;
export default tasksSlice.reducer;

export const fetchTasks = createAction<FetchTasksInputType>("fetchTasks");
export const createTask = createAction<NewTask>("createTask");
export const toggleTask = createAction<ToggleTaskInputType>("toggleTask");
export const deleteTask = createAction<DeleteTaskInputType>("deleteTask");
