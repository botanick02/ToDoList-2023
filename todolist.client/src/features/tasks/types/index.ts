export interface Task {
  id: number;
  title: string;
  dueDate?: Date;
  categoryId: number;
  isDone: boolean;
}
