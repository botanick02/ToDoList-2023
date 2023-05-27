import { Epic, ofType } from "redux-observable";
import { from, mergeMap } from "rxjs";
import { fetchStorageSourcesApi } from "../../graphql/storageSourcesApi";
import {
  setCurrentStorageSource,
  storageSourcesFetched,
} from "../reducers/storageSource-slice";

export const fetchStorageSourcesEpic: Epic = (action$) => {
  return action$.pipe(
    ofType("fetchStorageSources"),
    mergeMap(() =>
      from(fetchStorageSourcesApi()).pipe(
        mergeMap((response) => [
          setCurrentStorageSource(response.storageSources.getStorageSources[0]),
          storageSourcesFetched(response.storageSources.getStorageSources),
        ])
      )
    )
  );
};
