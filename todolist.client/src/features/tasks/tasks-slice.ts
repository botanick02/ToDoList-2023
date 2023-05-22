import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ITask, ITaskInputType } from "./types";

interface TasksSlice {
  tasksList: ITask[];
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
      categoryId: 0,
      isDone: true,
    },
  ],
};

const tasksSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    addTask: (state, action: PayloadAction<ITaskInputType>) => {
      const newTask: ITask = {
        id: Date.now(),
        title: action.payload.title,
        dueDate: action.payload.dueDate !== "" ? action.payload.dueDate + "Z" : "",
        categoryId: +action.payload.categoryId,
        isDone: false,
      };
      state.tasksList.push(newTask);
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

export const { addTask, toggleTask, deleteTask } = tasksSlice.actions;
export default tasksSlice.reducer;
