import { Epic, ofType } from "redux-observable";
import { from, map, mergeMap } from "rxjs";
import {
  createTask,
  deleteTask,
  fetchTasks,
  taskCreated,
  taskDeleted,
  taskToggled,
  tasksFetched,
  toggleTask,
} from "../reducers/tasks-slice";
import {
  createTaskApi,
  deleteTaskApi,
  fetchTasksApi,
  toggleTaskApi,
} from "../../graphql/tasksApi";
import { Action } from "@reduxjs/toolkit";
import { fetchTasksPaged } from "../../utils/fetchHelper";

export const fetchTasksEpic: Epic = (action$) => {
  return action$.pipe(
    ofType("fetchTasks"),
    mergeMap((action) =>
      from(
        fetchTasksApi(action.payload.pageNumber, action.payload.pageSize)
      ).pipe(map((response) => tasksFetched(response.tasks.getTasks)))
    )
  );
};

export const createTaskEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof createTask>, any, any>("createTask"),
    mergeMap((action) =>
      from(createTaskApi(action.payload)).pipe(
        mergeMap((response) => [
          fetchTasks({pageNumber: 1, pageSize: 5}),
          taskCreated(response.tasks.createTask)])
      )
    )
  );

export const deleteTaskEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof deleteTask>, any, any>("deleteTask"),
    mergeMap((action) =>
      from(deleteTaskApi(action.payload)).pipe(
        map((response) => {
          fetchTasksPaged();
          return taskDeleted(response.tasks.deleteTask)
        })
      )
    )
  );

export const toggleTaskEpic: Epic = (action$) =>
  action$.pipe(
    ofType<Action<typeof toggleTask>, any, any>("toggleTask"),
    mergeMap((action) =>
      from(toggleTaskApi(action.payload)).pipe(
        map((response) => {
          fetchTasksPaged();
          return taskToggled(response.tasks.toggleIsDone)
        })
      )
    )
  );
