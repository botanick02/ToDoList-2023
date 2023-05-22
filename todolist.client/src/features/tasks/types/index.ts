export interface ITask {
  id: number;
  title: string;
  dueDate: string;
  categoryId: number;
  isDone: boolean;
}

export interface ITaskInputType {
  title: string;
  dueDate: string;
  categoryId: number;
}

export interface ICategory {
  id: number;
  name: string;
}