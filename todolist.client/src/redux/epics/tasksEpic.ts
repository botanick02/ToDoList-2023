import { Epic, ofType } from "redux-observable";
import {from, map, mergeMap} from "rxjs";
import { tasksFetched } from "../slices/tasks-slice";
import { getTasks } from "../../graphql/tasksApi";
import { Action } from "@reduxjs/toolkit";


export const fetchTasksEpic: Epic<Action<any>, Action<any>, void, any> = (action$) => {
    return action$.pipe(
        ofType("fetchTasks"),
        mergeMap(action => from(getTasks()).pipe(map(response => tasksFetched(response.data.tasks.getTasks)))
        )
    )
}