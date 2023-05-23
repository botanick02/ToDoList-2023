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
    addTask: (state, action: PayloadAction<ITaskInputType>) => {
      const newTask: ITask = {
        id: Date.now(),
        title: action.payload.title,
        dueDate:
          action.payload.dueDate !== "" ? action.payload.dueDate + "Z" : "",
        categoryId: +action.payload.categoryId,
        isDone: false,
      };
      state.tasksList.push(newTask);
    },
    tasksFetched: (state, action: PayloadAction<ITask[]>) => {
      state.tasksList = action.payload;
    },
    toggleTask: (state, action: PayloadAction<number>) => {
      const taskId = action.payload;
      const task = state.tasksList.find((task) => task.id === taskId);
      if (task) {
        task.isDone = !task.isDone;
      }
    },
    deleteTask: (state, action: PayloadAction<number>) => {
      const taskId = action.payload;
      state.tasksList = state.tasksList.filter((task) => task.id !== taskId);
    },
  },
});

export const { addTask, toggleTask, deleteTask, tasksFetched } = tasksSlice.actions;
export default tasksSlice.reducer;


export const fetchTasks = createAction("fetchTasks");
