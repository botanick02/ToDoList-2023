import { GraphQlResponse } from "./graphqlReponse";

export type FetchStorageSourcesResponse = GraphQlResponse<{
  storageSources: {
    getStorageSources: string[];
  };
}>;
