import { PayloadAction, createAction, createSlice } from "@reduxjs/toolkit";

type StorageSourceSlice = {
  storagesList: string[];
  currentStorage?: string;
};

const initialState: StorageSourceSlice = {
  storagesList: [],
  currentStorage: undefined,
};

const storageSource = createSlice({
  name: "storageSource",
  initialState,
  reducers: {
    storageSourcesFetched: (state, action: PayloadAction<string[]>) => {
      state.storagesList = action.payload;
    },
    setCurrentStorageSource: (state, action: PayloadAction<string>) => {
      state.currentStorage = action.payload;
    },
  },
});

export const { storageSourcesFetched, setCurrentStorageSource } =
  storageSource.actions;

export default storageSource.reducer;

export const fetchStorageSources = createAction("fetchStorageSources");
