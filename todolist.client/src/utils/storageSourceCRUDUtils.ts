import { currentStorageSourceSet } from "../redux/reducers/storageSource-slice";
import { store } from "../redux/store";
import {
  writeDefaultIfEmptyLocalStorage,
  writeToLocalStorage,
} from "./localstorageUtils";

export const setCurrentStorageSource = (source: string) => {
  store.dispatch(currentStorageSourceSet(source));
  writeToLocalStorage("Source", source);
};

export const setLocalOrDefaultStorageSource = async (defaultSource: string) => {
  const source = writeDefaultIfEmptyLocalStorage("Source", defaultSource);
  store.dispatch(currentStorageSourceSet(source));
};
