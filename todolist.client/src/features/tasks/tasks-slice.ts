import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { Task } from "./types";

interface TasksSlice {
  tasksList: Task[];
}

const initialState: TasksSlice = {
  tasksList: [
    {
      id: 1,
      title: "Complete assignment",
      dueDate: new Date("2023-05-20"),
      categoryId: 2,
      isDone: false,
    },
    {
      id: 2,
      title: "Read a book",
      dueDate: undefined,
      categoryId: 1,
      isDone: false,
    },
    {
      id: 3,
      title: "Buy groceries",
      dueDate: new Date("2023-05-21"),
      categoryId: 3,
      isDone: true,
    },
  ],
};

const tasksSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    addTask: (state, action: PayloadAction<Task>) => {
      state.tasksList.push(action.payload);
    },
  },
});

export const { addTask } = tasksSlice.actions;
export default tasksSlice.reducer;
