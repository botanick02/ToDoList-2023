import { store } from "../redux/store";
import { GraphQlData, GraphQlResponse } from "./types/graphqlReponse";
const API_URL = "https://localhost:7182/graphql";

export async function graphQLFetch<T extends GraphQlData>(
  query: string,
  variables = {}
): Promise<T> {
  const getSourceNameFromState = (): string => {
    const state = store.getState();
    return state.storageSources.currentStorage ?? "";
  };

  const res = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Source: getSourceNameFromState(),
    },
    body: JSON.stringify({ query, variables }),
  });

  if (!res.ok) {
    throw new Error(`${res.status}: ${res.statusText}`);
  }

  const graphQlRes: GraphQlResponse<T> = await res.json();

  if (graphQlRes.errors) {
    throw new Error(graphQlRes.errors.map((err) => err.message).join("\n"));
  }
  return graphQlRes.data;
}
