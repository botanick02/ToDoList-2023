export type Category = {
  id: number;
  name: string;
};

export type NewCategory = {
  name: string;
};

export type DeleteCategoryInput = {
  id: number;
};

export type FetchCategoriesInputType = {
  pageNumber: number;
  pageSize: number;
};