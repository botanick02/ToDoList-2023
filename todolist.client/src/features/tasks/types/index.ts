export interface Task {
  id: number;
  title: string;
  dueDate: string;
  categoryId: number;
  isDone: boolean;
}

export interface TaskInputType {
  title: string;
  dueDate: string;
  categoryId: number;
}

export interface Category {
  id: number;
  name: string;
}