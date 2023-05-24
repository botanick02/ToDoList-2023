import { Epic, ofType } from "redux-observable";
import {from, map, mergeMap} from "rxjs";
import { tasksFetched } from "../reducers/tasks-slice";
import { fetchTasksApi } from "../../graphql/tasksApi";
import { Action } from "@reduxjs/toolkit";


export const fetchTasksEpic: Epic<Action<any>, Action<any>, void, any> = (action$) => {
    return action$.pipe(
        ofType("fetchTasks"),
        mergeMap(action => from(fetchTasksApi()).pipe(map(response => tasksFetched(response.tasks.allTasks)))
        )
    )
}

