import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { Task, TaskInputType } from "./types";

interface TasksSlice {
  tasksList: Task[];
}

const initialState: TasksSlice = {
  tasksList: [
    {
      id: 1,
      title: "Complete assignment",
      dueDate: "2023-05-20T15:30Z",
      categoryId: 2,
      isDone: false,
    },
    {
      id: 234234,
      title: "Complete assignment",
      dueDate: "2023-05-20T13:30Z",
      categoryId: 2,
      isDone: false,
    },
    {
      id: 2,
      title: "Read a book",
      dueDate: "",
      categoryId: 1,
      isDone: false,
    },
    {
      id: 3,
      title: "Buy groceries",
      dueDate: "2023-05-21T10:00Z",
      categoryId: 3,
      isDone: true,
    },
  ],
};

const tasksSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    addTask: (state, action: PayloadAction<TaskInputType>) => {
      const newTask: Task = {
        id: Date.now(),
        title: action.payload.title,
        dueDate: action.payload.dueDate,
        categoryId: +action.payload.categoryId,
        isDone: false,
      };
      state.tasksList.push(newTask);
    },
    toggleTask: (state, action: PayloadAction<number>) => {
      const task = state.tasksList.find((task) => task.id === action.payload);
      if (task) {
        task.isDone = !task.isDone;
      }
    },
  },
});

export const { addTask, toggleTask } = tasksSlice.actions;
export default tasksSlice.reducer;
