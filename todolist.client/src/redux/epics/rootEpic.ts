import { combineEpics } from 'redux-observable';
import { fetchTasksEpic } from './tasksEpic';
import { fetchCategoriesEpic } from './categoriesEpic';

export const rootEpic = combineEpics(
    fetchTasksEpic,
    fetchCategoriesEpic,
  );
