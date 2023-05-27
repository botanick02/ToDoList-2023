import { graphQLFetch } from "./api";
import { FetchStorageSourcesResponse } from "./types/storageSources";

const getStorageSourcesQuery = `
    query getStorageSources{
        storageSources{
        getStorageSources
        }
    }
`;

export const fetchStorageSourcesApi = async () => {
  try {
    return await graphQLFetch<FetchStorageSourcesResponse>(
      getStorageSourcesQuery
    );
  } catch (error) {
    console.error("Error fetching categories:", error);
    throw error;
  }
};
