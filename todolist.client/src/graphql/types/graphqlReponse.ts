export type GraphQlData = { [key: string]: any; [index: number]: never };

export interface GraphQlResponse<T extends GraphQlData> {
  data: T;
  errors?: Array<{ message: string }>;
  [key: string]: any;
  [index: number]: never;
}
