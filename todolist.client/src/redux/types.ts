export interface ITask {
  id: number;
  title: string;
  dueDate: string;
  categoryId: number;
  isDone: boolean;
}


export type NewTaskInputType = {
  title: string;
  dueDate: string;
  categoryId: string;
};

export type NewTaskType = {
  title: string;
  dueDate?: Date;
  categoryId: number;
};

export interface ICategory {
  id: number;
  name: string;
}

export type NewCategoryInputType = {
  name: string;
};


