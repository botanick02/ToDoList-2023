export type Task = {
  id: number;
  title: string;
  dueDate: string;
  categoryId: number;
  isDone: boolean;
};

export type NewTask = {
  title: string;
  dueDate?: Date;
  categoryId: number;
};

export type DeleteTaskInputType = {
  taskId: number;
};

export type ToggleTaskInputType = {
  taskId: number;
};
