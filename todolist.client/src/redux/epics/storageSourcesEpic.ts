import { Epic, ofType } from "redux-observable";
import { from, mergeMap, map } from "rxjs";
import { fetchStorageSourcesApi } from "../../graphql/storageSourcesApi";
import { storageSourcesFetched } from "../reducers/storageSource-slice";
import { setLocalOrDefaultStorageSource } from "../../utils/storageSourceCRUDUtils";

export const fetchStorageSourcesEpic: Epic = (action$) => {
  return action$.pipe(
    ofType("fetchStorageSources"),
    mergeMap(() =>
      from(fetchStorageSourcesApi()).pipe(
        map((response) => {
          setLocalOrDefaultStorageSource(
            response.storageSources.getStorageSources[0]
          );
          return storageSourcesFetched(
            response.storageSources.getStorageSources
          );
        })
      )
    )
  );
};
